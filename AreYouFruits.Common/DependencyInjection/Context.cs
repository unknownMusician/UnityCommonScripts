using AreYouFruits.DependencyInjection.ContextInitialization;
using AreYouFruits.DependencyInjection.TypeResolvers;

namespace AreYouFruits.DependencyInjection
{
    public static class Context
    {
        public static readonly IDiContainer Container = new ContextInitializerDiContainerDecorator(new DiContainer());
    }
}