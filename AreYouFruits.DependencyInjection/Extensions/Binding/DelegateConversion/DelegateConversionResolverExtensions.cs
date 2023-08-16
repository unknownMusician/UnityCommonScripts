using System;
using AreYouFruits.DependencyInjection.Extensions.Binding.DelegateConversion;
using AreYouFruits.DependencyInjection.Extensions.Binding.Generic;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
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