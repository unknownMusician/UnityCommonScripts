using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace AreYouFruits.Common
{
    public static class Tasks
    {
        [Obsolete("Use Task.Delay(TimeSpan.FromSeconds(seconds)) instead")]
        public static async Task DelaySeconds(float seconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
        }

        public static async Task LerpAsync(
            float time, Action<float> lerpConsumer, Func<bool>? conditionProvider = null,
            CancellationToken cancellation = default
        )
        {
            conditionProvider ??= () => true;

            Func<bool> condition = () => conditionProvider() && !cancellation.IsCancellationRequested;

            float lerp = 0.0f;

            while (lerp < 1.0f && condition())
            {
                lerpConsumer(lerp);

                lerp += Time.deltaTime / time;

                await Task.Yield();
            }

            if (condition())
            {
                lerpConsumer(1.0f);
            }
        }
    }
}
