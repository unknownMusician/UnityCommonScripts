using System;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Extensions.Binding.Conversion;

namespace AreYouFruits.DependencyInjection
{
    public static class ConversionResolverExtensions
    {
        public static void To<TSource, TDestination>(
            this IGenericDiBinder<TSource> binder, Func<TDestination, TSource> converter
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