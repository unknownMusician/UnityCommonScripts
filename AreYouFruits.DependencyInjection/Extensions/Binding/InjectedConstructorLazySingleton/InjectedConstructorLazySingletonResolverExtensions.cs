using AreYouFruits.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.DependencyInjection.Extensions.Binding.InjectedConstructorLazySingleton;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class InjectedConstructorLazySingletonResolverExtensions
    {
        public static void ToInjectedConstructorLazySingleton<TDestination, TSource>(this IGenericDiBinder<TDestination> binder)
            where TSource : class, TDestination
        {
            binder.To(new InjectedConstructorLazySingletonResolver<TSource>());
        }
        
        public static void ToInjectedConstructorLazySingleton<T>(this IGenericDiBinder<T> binder)
            where T : class
        {
            binder.ToInjectedConstructorLazySingleton<T, T>();
        }
    }
}