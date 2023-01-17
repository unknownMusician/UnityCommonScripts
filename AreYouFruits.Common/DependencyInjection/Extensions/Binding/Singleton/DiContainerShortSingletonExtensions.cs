namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortSingletonExtensions
    {
        public static void BindToSingleton<T>(this IDiContainer container, T value)
        {
            container.Bind<T>().To(value);
        }
    }
}