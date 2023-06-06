using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic
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