using AreYouFruits.DependencyInjection.Extensions.Binding.Factory;
using AreYouFruits.DependencyInjection.TypeResolvers;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortLazySingletonExtensions
    {
        public static void BindToLazySingleton<T>(this IDiContainer container, IFactory<T> factory)
        {
            container.Bind<T>().ToLazySingleton(factory);
        }
    }
}