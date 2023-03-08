namespace AreYouFruits.DependencyInjection.Resolvers
{
    public sealed class ResolverObjectWrapper<TSource> : IResolver<object>
    {
        private readonly IResolver<TSource> resolver;

        public ResolverObjectWrapper(IResolver<TSource> resolver)
        {
            this.resolver = resolver;
        }
        
        public object Resolve(IDiByTypeResolver resolver)
        {
            return (object)this.resolver.Resolve(resolver)!;
        }
    }
}