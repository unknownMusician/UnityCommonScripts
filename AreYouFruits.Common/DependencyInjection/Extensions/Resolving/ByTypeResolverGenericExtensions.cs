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

        public static bool TryResolve<T>(this IDiByTypeResolver resolver, out T value)
        {
            if (resolver.TryResolve(typeof(T), out object potentialValue))
            {
                value = (T)potentialValue;
                return true;
            }

            value = default!;
            return false;
        }
    }
}
