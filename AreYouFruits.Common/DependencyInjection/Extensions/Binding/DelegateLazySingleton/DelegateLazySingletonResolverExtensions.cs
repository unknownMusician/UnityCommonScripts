using System;
using AreYouFruits.Common.DependencyInjection.Binders;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.DelegateLazySingleton
{
    public static class DelegateLazySingletonResolverExtensions
    {
        public static void ToLazySingleton<TSource>(this IGenericDiBinder<TSource> binder, Func<TSource> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            
            binder.To(new DelegateLazySingletonResolver<TSource>(factory));
        }
        
        public static void ToLazySingleton(this IDiBinder binder, Func<object> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            
            binder.To(new DelegateLazySingletonResolver<object>(factory));
        }
    }
}