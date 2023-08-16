using AreYouFruits.DependencyInjection.TypeResolvers;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortSingletonExtensions
    {
        public static void BindToSingleton<T>(this IDiContainer container, T value)
        {
            container.Bind<T>().ToSingleton(value);
        }
    }
}