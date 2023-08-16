using System;
using System.Threading;
using System.Threading.Tasks;

namespace AreYouFruits.Tasks
{
    public static class TaskExtensions
    {
        public static async Task DoNotThrowCancellation(this Task task)
        {
            try
            {
                await task;
            }
            catch (OperationCanceledException) { }
        }

        public static async Task WithCancellation(this Task task, CancellationToken cancellation)
        {
            cancellation.ThrowIfCancellationRequested();
            
            await Task.WhenAny(task, Task.Delay(-1, cancellation));
        }

        public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellation)
        {
            cancellation.ThrowIfCancellationRequested();
            
            Task resultTask = await Task.WhenAny(task, Task.Delay(-1, cancellation));

            return ((Task<T>)resultTask).Result;
        }
    }
}

