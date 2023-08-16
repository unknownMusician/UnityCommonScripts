using AreYouFruits.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.DependencyInjection.Extensions.Binding.InjectedConstructorFactory;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class InjectedConstructorFactoryResolverExtensions
    {
        public static void ToInjectedConstructorFactory<TDestination, TSource>(this IGenericDiBinder<TDestination> binder)
            where TSource : class, TDestination
        {
            binder.To(new InjectedConstructorFactoryResolver<TSource>());
        }
        
        public static void ToInjectedConstructorFactory<T>(this IGenericDiBinder<T> binder)
            where T : class
        {
            binder.ToInjectedConstructorFactory<T, T>();
        }
    }
}