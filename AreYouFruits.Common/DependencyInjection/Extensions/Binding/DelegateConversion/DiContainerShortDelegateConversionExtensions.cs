using System;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.DelegateConversion
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