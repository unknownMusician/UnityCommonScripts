using AreYouFruits.Common.DependencyInjection;
using AreYouFruits.Common.DependencyInjection.ContextInitialization;
using UnityEngine;

namespace AreYouFruits.Common.Unity.DependencyInjection
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