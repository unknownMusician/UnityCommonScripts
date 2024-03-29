﻿using System;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Extensions.Binding.DelegateLazySingleton;
using AreYouFruits.DependencyInjection.Extensions.Binding.Generic;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
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