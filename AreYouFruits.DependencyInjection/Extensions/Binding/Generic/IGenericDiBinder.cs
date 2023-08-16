using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection.Extensions.Binding.Generic
{
    public interface IGenericDiBinder<in TSource>
    {
        public void To(IResolver<TSource> resolver);
        public void To<TDestination>()
            where TDestination : TSource;
    }
}