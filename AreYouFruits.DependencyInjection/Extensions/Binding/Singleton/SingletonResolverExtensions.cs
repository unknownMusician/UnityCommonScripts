using System;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.DependencyInjection.Extensions.Binding.Singleton;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class SingletonResolverExtensions
    {
        public static void ToSingleton(this IDiBinder binder, object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            
            binder.To(new SingletonResolver<object>(obj));
        }
        
        public static void ToSingleton<TSource, TDestination>(this IGenericDiBinder<TSource> binder, TDestination value)
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