using AreYouFruits.Common.DependencyInjection.Resolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic
{
    public interface IGenericDiBinder<in TSource>
    {
        public void To(IResolver<TSource> resolver);
        public void To<TDestination>()
            where TDestination : TSource;
    }
}