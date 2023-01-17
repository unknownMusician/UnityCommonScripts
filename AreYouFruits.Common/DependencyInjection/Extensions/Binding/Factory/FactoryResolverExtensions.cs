using System;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Extensions.Binding.Factory;
using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection
{
    public static class FactoryResolverExtensions
    {
        public static void To(this IDiBinder binder, Func<object> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            binder.To(new FactoryResolver<object>(factory));
        }

        public static void To<TSource>(this IGenericDiBinder<TSource> binder, Func<TSource> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            binder.To(new FactoryResolver<TSource>(factory));
        }
    }
}