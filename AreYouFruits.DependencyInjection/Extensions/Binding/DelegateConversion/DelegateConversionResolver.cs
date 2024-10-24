﻿using System;
using AreYouFruits.DependencyInjection.Resolvers;
using AreYouFruits.DependencyInjection.TypeResolvers;

namespace AreYouFruits.DependencyInjection.Extensions.Binding.DelegateConversion
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

            var destination = resolver.Resolve<TDestination>();

            return converter(destination);
        }
    }
}