namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerShortFactoryExtensions
    {
        public static void BindToFactory<T>(this IDiContainer container, IFactory<T> factory)
        {
            container.Bind<T>().ToFactory(factory);
        }
    }
}