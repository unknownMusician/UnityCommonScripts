using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.Singleton
{
    public static class DiContainerShortSingletonExtensions
    {
        public static void BindToSingleton<T>(this IDiContainer container, T value)
        {
            container.Bind<T>().ToSingleton(value);
        }
    }
}