using System;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.DelegateFactory
{
    public static class DiContainerShortDelegateFactoryExtensions
    {
        public static void BindToFactory<T>(this IDiContainer container, Func<T> factory)
        {
            container.Bind<T>().ToFactory(factory);
        }
    }
}