using System;
using System.Threading.Tasks;
using UnityEngine;

namespace AreYouFruits.Tasks.Unity
{
    public static class LoggingTaskExtensions
    {
        public static async void CatchAndLog(this Task task)
        {
            try
            {
                await task;
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
        }
    }
}