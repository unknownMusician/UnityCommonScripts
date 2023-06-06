using AreYouFruits.Common.DependencyInjection.ContextInitialization;
using AreYouFruits.Common.DependencyInjection.KeyedTypeResolvers;

namespace AreYouFruits.Common.DependencyInjection
{
    public static class EditorContext
    {
        public static IKeyedDiContainer Container { get; }

        static EditorContext()
        {
            Container = new ContextInitializerKeyedDiContainerDecorator(new KeyedDiContainer(), Initialize);
        }

        private static void Initialize(IKeyedDiContainer container)
        {
            ContextInitializer.TryInitialize(container, ContextType.Editor);
        }
    }
}