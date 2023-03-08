﻿using AreYouFruits.DependencyInjection.ContextInitialization;

namespace AreYouFruits.DependencyInjection
{
    public static class Context
    {
        public static IKeyedDiContainer Container { get; }

        static Context()
        {
            Container = new ContextInitializerKeyedDiContainerDecorator(new KeyedDiContainer(), Initialize);
        }

        private static void Initialize(IKeyedDiContainer container)
        {
            ContextInitializer.TryInitialize(container, ContextType.Runtime);
        }
    }
}