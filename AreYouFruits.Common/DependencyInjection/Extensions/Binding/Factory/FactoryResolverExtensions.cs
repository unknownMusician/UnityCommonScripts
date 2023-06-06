using System;
using AreYouFruits.Common.DependencyInjection.Binders;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.Factory
{
    public static class FactoryResolverExtensions
    {
        public static void ToFactory(this IDiBinder binder, IFactory<object> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            binder.To(new FactoryResolver<object>(factory));
        }

        public static void ToFactory<TSource>(this IGenericDiBinder<TSource> binder, IFactory<TSource> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            binder.To(new FactoryResolver<TSource>(factory));
        }
    }
}