using System;
using AreYouFruits.Common.DependencyInjection.Binders;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Factory;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.LazySingleton
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