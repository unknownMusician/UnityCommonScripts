using System;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.Conversion
{
    public static class ConversionResolverExtensions
    {
        public static void ToConversion<TSource, TDestination>(
            this IGenericDiBinder<TSource> binder, IConverter<TDestination, TSource> converter
        )
        {
            if (converter is null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            binder.To(new ConversionResolver<TSource, TDestination>(converter));
        }
    }
}