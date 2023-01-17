using System;

namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortFactoryExtensions
    {
        public static void BindToFactory<T>(this IDiContainer container, Func<T> factory)
        {
            container.Bind<T>().To(factory);
        }
    }
}