using System;
using System.Threading.Tasks;
using UnityEngine;

namespace AreYouFruits.Common
{
    public static class VoidTasks
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