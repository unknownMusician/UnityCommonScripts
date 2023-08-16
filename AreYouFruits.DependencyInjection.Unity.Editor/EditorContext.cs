using AreYouFruits.DependencyInjection.ContextInitialization;
using AreYouFruits.DependencyInjection.KeyedTypeResolvers;

namespace AreYouFruits.DependencyInjection.Unity.Editor
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