using System;
using AreYouFruits.Common.DependencyInjection.Binders;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.DelegateFactory
{
    public static class DelegateFactoryResolverExtensions
    {
        public static void ToFactory(this IDiBinder binder, Func<object> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            binder.To(new DelegateFactoryResolver<object>(factory));
        }

        public static void ToFactory<TSource>(this IGenericDiBinder<TSource> binder, Func<TSource> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            binder.To(new DelegateFactoryResolver<TSource>(factory));
        }
    }
}