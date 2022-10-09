using System;
using System.Threading;
using System.Threading.Tasks;

namespace AreYouFruits.Common
{
    public static partial class Tasks
    {
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

