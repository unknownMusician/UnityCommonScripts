using System;
using AreYouFruits.DependencyInjection.Resolvers;
using AreYouFruits.DependencyInjection.TypeResolvers;

namespace AreYouFruits.DependencyInjection.Extensions.Binding.Conversion
{
    public sealed class ConversionResolver<TSource, TDestination> : IResolver<TSource>
    {
        private readonly IConverter<TDestination, TSource> converter;

        public ConversionResolver(IConverter<TDestination, TSource> converter)
        {
            if (converter is null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            this.converter = converter;
        }

        public TSource Resolve(IDiByTypeResolver resolver)
        {
            if (resolver is null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }

            var destination = resolver.Resolve<TDestination>();

            return converter.Convert(destination);
        }
    }
}