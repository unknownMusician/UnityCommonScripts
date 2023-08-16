using AreYouFruits.DependencyInjection.TypeResolvers;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortInjectedConstructorLazySingletonExtensions
    {
        public static void BindToInjectedConstructorLazySingleton<TDestination, TSource>(this IDiContainer container)
            where TSource : class, TDestination
        {
            container.Bind<TDestination>().ToInjectedConstructorLazySingleton<TDestination, TSource>();
        }
        
        public static void BindToInjectedConstructorLazySingleton<T>(this IDiContainer container)
            where T : class
        {
            container.BindToInjectedConstructorLazySingleton<T, T>();
        }
    }
}