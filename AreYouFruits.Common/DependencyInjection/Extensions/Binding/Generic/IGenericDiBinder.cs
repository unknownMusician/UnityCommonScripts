using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection.Binders
{
    public interface IGenericDiBinder<in TSource>
    {
        public void To(IResolver<TSource> resolver);
        public void To<TDestination>()
            where TDestination : TSource;
    }
}