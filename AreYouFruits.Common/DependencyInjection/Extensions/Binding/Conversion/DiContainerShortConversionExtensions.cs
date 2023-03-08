﻿namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortConversionExtensions
    {
        public static void BindToConversion<TSource, TDestination>(
            this IDiContainer container, IConverter<TDestination, TSource> converter
        )
        {
            container.Bind<TSource>().ToConversion(converter);
        }
    }
}