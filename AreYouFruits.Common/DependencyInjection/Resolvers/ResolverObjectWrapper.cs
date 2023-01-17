namespace AreYouFruits.DependencyInjection.Resolvers
{
    public sealed class ResolverObjectWrapper<TSource> : IResolver<object>
    {
        private readonly IResolver<TSource> _resolver;

        public ResolverObjectWrapper(IResolver<TSource> resolver)
        {
            _resolver = resolver;
        }
        
        public object Resolve(IDiByTypeResolver resolver)
        {
            return (object)_resolver.Resolve(resolver)!;
        }
    }
}