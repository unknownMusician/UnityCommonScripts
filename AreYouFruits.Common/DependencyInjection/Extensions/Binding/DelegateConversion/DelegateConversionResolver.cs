using System;
using AreYouFruits.Common.DependencyInjection.Extensions.Resolving;
using AreYouFruits.Common.DependencyInjection.Resolvers;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.DelegateConversion
{
    public sealed class DelegateConversionResolver<TSource, TDestination> : IResolver<TSource>
    {
        private readonly Func<TDestination, TSource> converter;

        public DelegateConversionResolver(Func<TDestination, TSource> converter)
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

            TDestination destination = resolver.Resolve<TDestination>();

            return converter(destination);
        }
    }
}