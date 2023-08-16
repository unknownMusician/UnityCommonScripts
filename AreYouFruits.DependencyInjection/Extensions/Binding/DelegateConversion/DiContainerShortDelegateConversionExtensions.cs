using System;
using AreYouFruits.DependencyInjection.TypeResolvers;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortDelegateConversionExtensions
    {
        public static void BindToConversion<TSource, TDestination>(
            this IDiContainer container, Func<TDestination, TSource> converter
        )
        {
            container.Bind<TSource>().ToConversion(converter);
        }
    }
}