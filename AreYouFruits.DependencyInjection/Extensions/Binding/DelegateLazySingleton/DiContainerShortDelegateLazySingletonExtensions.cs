using System;
using AreYouFruits.DependencyInjection.TypeResolvers;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortDelegateLazySingletonExtensions
    {
        public static void BindToLazySingleton<T>(this IDiContainer container, Func<T> factory)
        {
            container.Bind<T>().ToLazySingleton(factory);
        }
    }
}