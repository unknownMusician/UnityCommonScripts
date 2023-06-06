using AreYouFruits.Common.DependencyInjection.Resolvers;

namespace AreYouFruits.Common.DependencyInjection.Binders
{
    public interface IDiBinder
    {
        public void To(IResolver<object> resolver);
    }
}