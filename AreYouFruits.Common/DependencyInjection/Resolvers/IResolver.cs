namespace AreYouFruits.DependencyInjection.Resolvers
{
    public interface IResolver<out TSource>
    {
        public TSource Resolve(IDiByTypeResolver resolver);
    }
}
