using System;

namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortConversionExtensions
    {
        public static void BindToConversion<TSource, TDestination>(
            this IDiContainer container, Func<TDestination, TSource> converter
        )
        {
            container.Bind<TSource>().To(converter);
        }
    }
}