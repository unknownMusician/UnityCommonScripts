using System;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.DelegateConversion
{
    public static class DelegateConversionResolverExtensions
    {
        public static void ToConversion<TSource, TDestination>(
            this IGenericDiBinder<TSource> binder, Func<TDestination, TSource> converter
        )
        {
            if (converter is null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            binder.To(new DelegateConversionResolver<TSource, TDestination>(converter));
        }
    }
}