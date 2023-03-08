using System;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Extensions.Binding.LazySingleton;

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