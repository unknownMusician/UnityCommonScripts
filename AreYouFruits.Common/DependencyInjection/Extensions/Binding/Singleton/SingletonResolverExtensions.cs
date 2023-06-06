using System;
using AreYouFruits.Common.DependencyInjection.Binders;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.Singleton
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