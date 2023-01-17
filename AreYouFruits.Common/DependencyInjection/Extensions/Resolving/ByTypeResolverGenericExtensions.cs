namespace AreYouFruits.DependencyInjection
{
    public static class ByTypeResolverGenericExtensions
    {
        public static T Resolve<T>(this IDiByTypeResolver resolver)
        {
            return (T)resolver.Resolve(typeof(T));
        }

        public static void Resolve<T>(this IDiByTypeResolver resolver, out T value)
        {
            value = resolver.Resolve<T>();
        }
    }
}
