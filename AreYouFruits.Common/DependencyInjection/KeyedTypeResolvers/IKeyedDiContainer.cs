using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.KeyedTypeResolvers
{
    public interface IKeyedDiContainer : IDiContainer
    {
        public IDiContainer For(object key);
    }
}