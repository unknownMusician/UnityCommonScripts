using System;
using System.Threading;
using System.Threading.Tasks;

namespace AreYouFruits.Common
{
    public static class Tasks
    {
        public static async Task Repeat(this Action action, CancellationToken cancellation)
        {
            while (!cancellation.IsCancellationRequested)
            {
                action();
                
                await Task.Yield();
            }
        }
        
        public static async Task LerpAsync(
            float time, Func<float> timeProvider, Action<float> lerpConsumer, Func<bool>? conditionProvider = null,
            CancellationToken cancellation = default
        )
        {
            conditionProvider ??= () => true;

            Func<bool> condition = () => conditionProvider() && !cancellation.IsCancellationRequested;

            float timeStart = timeProvider();
            
            float t = 0.0f;

            bool conditionSatisfied = condition();

            while ((t < 1.0f) && conditionSatisfied)
            {
                lerpConsumer(t);

                await Task.Yield();
                
                t = (timeProvider() - timeStart) / time;
                conditionSatisfied = condition();
            }

            if (conditionSatisfied)
            {
                lerpConsumer(1.0f);
            }
        }
    }
}

