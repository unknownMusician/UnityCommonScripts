using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.Factory
{
    public static class DiContainerShortFactoryExtensions
    {
        public static void BindToFactory<T>(this IDiContainer container, IFactory<T> factory)
        {
            container.Bind<T>().ToFactory(factory);
        }
    }
}