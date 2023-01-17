using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection.Binders
{
    public interface IDiBinder
    {
        public void To(IResolver<object> resolver);
    }
}