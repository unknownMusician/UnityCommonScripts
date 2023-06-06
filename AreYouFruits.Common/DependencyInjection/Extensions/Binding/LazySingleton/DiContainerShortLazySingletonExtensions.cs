using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Factory;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.LazySingleton
{
    public static class DiContainerShortLazySingletonExtensions
    {
        public static void BindToLazySingleton<T>(this IDiContainer container, IFactory<T> factory)
        {
            container.Bind<T>().ToLazySingleton(factory);
        }
    }
}