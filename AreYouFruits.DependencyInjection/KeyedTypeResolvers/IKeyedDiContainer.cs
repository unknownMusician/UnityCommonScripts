using AreYouFruits.DependencyInjection.TypeResolvers;

namespace AreYouFruits.DependencyInjection.KeyedTypeResolvers
{
    public interface IKeyedDiContainer : IDiContainer
    {
        public IDiContainer For(object key);
    }
}