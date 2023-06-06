using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.InjectedConstructorLazySingleton
{
    public static class InjectedConstructorLazySingletonResolverExtensions
    {
        public static void ToInjectedConstructorLazySingleton<TDestination, TSource>(this IGenericDiBinder<TDestination> binder)
            where TSource : class, TDestination
        {
            binder.To(new InjectedConstructorLazySingletonResolver<TSource>());
        }
    }
}