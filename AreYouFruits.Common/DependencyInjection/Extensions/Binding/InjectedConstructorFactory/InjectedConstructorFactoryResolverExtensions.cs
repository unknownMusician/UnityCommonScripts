using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.InjectedConstructorFactory
{
    public static class InjectedConstructorFactoryResolverExtensions
    {
        public static void ToInjectedConstructorFactory<TDestination, TSource>(this IGenericDiBinder<TDestination> binder)
            where TSource : class, TDestination
        {
            binder.To(new InjectedConstructorFactoryResolver<TSource>());
        }
    }
}