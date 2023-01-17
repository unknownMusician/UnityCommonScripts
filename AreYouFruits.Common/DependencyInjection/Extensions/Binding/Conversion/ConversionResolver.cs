using System;
using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection.Extensions.Binding.Conversion
{
    public sealed class ConversionResolver<TSource, TDestination> : IResolver<TSource>
    {
        private readonly Func<TDestination, TSource> _converter;

        public ConversionResolver(Func<TDestination, TSource> converter)
        {
            if (converter is null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            _converter = converter;
        }

        public TSource Resolve(IDiByTypeResolver resolver)
        {
            if (resolver is null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }

            TDestination destination = resolver.Resolve<TDestination>();

            return _converter(destination);
        }
    }
}