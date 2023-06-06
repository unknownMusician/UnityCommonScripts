using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.InjectedConstructorFactory
{
    public static class DiContainerShortInjectedConstructorFactoryExtensions
    {
        public static void BindToInjectedConstructorFactory<TDestination, TSource>(this IDiContainer container)
            where TSource : class, TDestination
        {
            container.Bind<TDestination>().ToInjectedConstructorFactory<TDestination, TSource>();
        }
    }
}