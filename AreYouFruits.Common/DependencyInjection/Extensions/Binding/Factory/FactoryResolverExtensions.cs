using System;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Extensions.Binding.Factory;

namespace AreYouFruits.DependencyInjection
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