using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.InjectedConstructorLazySingleton
{
    public static class DiContainerShortInjectedConstructorLazySingletonExtensions
    {
        public static void BindToInjectedConstructorLazySingleton<TDestination, TSource>(this IDiContainer container)
            where TSource : class, TDestination
        {
            container.Bind<TDestination>().ToInjectedConstructorLazySingleton<TDestination, TSource>();
        }
    }
}