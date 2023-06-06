using System;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.DelegateLazySingleton
{
    public static class DiContainerShortDelegateLazySingletonExtensions
    {
        public static void BindToLazySingleton<T>(this IDiContainer container, Func<T> factory)
        {
            container.Bind<T>().ToLazySingleton(factory);
        }
    }
}