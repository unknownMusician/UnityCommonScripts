using AreYouFruits.DependencyInjection.TypeResolvers;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortInjectedConstructorFactoryExtensions
    {
        public static void BindToInjectedConstructorFactory<TDestination, TSource>(this IDiContainer container)
            where TSource : class, TDestination
        {
            container.Bind<TDestination>().ToInjectedConstructorFactory<TDestination, TSource>();
        }
        
        public static void BindToInjectedConstructorFactory<T>(this IDiContainer container)
            where T : class
        {
            container.BindToInjectedConstructorFactory<T, T>();
        }
    }
}