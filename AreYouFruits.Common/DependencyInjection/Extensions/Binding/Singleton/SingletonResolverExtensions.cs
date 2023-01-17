using System;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Extensions.Binding.Singleton;
using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection
{
    public static class SingletonResolverExtensions
    {
        public static void To(this IDiBinder binder, object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            
            binder.To(new SingletonResolver<object>(obj));
        }
        
        public static void To<TSource, TDestination>(this IGenericDiBinder<TSource> binder, TDestination value)
            where TDestination : TSource
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            binder.To(new SingletonResolver<TSource>(value));
        }
    }
}