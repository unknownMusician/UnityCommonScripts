using System;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Extensions.Binding.Factory;
using AreYouFruits.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.DependencyInjection.Extensions.Binding.LazySingleton;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class LazySingletonResolverExtensions
    {
        public static void ToLazySingleton<TSource>(this IGenericDiBinder<TSource> binder, IFactory<TSource> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            
            binder.To(new LazySingletonResolver<TSource>(factory));
        }
        
        public static void ToLazySingleton(this IDiBinder binder, IFactory<object> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            
            binder.To(new LazySingletonResolver<object>(factory));
        }
    }
}