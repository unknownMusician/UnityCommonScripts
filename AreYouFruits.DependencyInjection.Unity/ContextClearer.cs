using AreYouFruits.DependencyInjection.ContextInitialization;
using UnityEngine;

namespace AreYouFruits.DependencyInjection.Unity
{
    public static class ContextClearer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Clear()
        {
            ContextInitializer.Reset();
            Context.Container.Clear();
        }
    }
}