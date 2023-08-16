using System;
using AreYouFruits.DependencyInjection.TypeResolvers;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortDelegateFactoryExtensions
    {
        public static void BindToFactory<T>(this IDiContainer container, Func<T> factory)
        {
            container.Bind<T>().ToFactory(factory);
        }
    }
}