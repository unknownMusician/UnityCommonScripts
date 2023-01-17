using System;

namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortLazySingletonExtensions
    {
        public static void BindToLazySingleton<T>(this IDiContainer container, Func<T> factory)
        {
            container.Bind<T>().ToLazySingleton(factory);
        }
    }
}