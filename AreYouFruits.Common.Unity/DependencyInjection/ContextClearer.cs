using AreYouFruits.DependencyInjection;
using AreYouFruits.DependencyInjection.ContextInitialization;
using UnityEngine;

namespace AreYouFruits.Common.DependencyInjection
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