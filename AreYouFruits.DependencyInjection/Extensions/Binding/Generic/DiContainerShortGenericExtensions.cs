using AreYouFruits.DependencyInjection.TypeResolvers;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortGenericExtensions
    {
        public static void BindTo<TSource, TDestination>(this IDiContainer container)
            where TDestination : TSource
        {
            container.Bind<TSource>().To<TDestination>();
        }
    }
}