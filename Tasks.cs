#if UNITY_2021_3_OR_NEWER

using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace AreYouFruits.Common
{
    public static class Tasks
    {
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
        
        public static async Task Repeat(this Action action, CancellationToken cancellation)
        {
            while (!cancellation.IsCancellationRequested)
            {
                action();
                
                await Task.Yield();
            }
        }
    }
}

#endif