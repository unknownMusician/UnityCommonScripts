using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Resolvers
{
    public interface IResolver<out TSource>
    {
        public TSource Resolve(IDiByTypeResolver resolver);
    }
}
