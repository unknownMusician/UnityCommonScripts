using System;
using AreYouFruits.Common.DependencyInjection.Resolvers;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.Factory
{
    public sealed class FactoryResolver<TSource> : IResolver<TSource>
    {
        private readonly IFactory<TSource> factory;

        public FactoryResolver(IFactory<TSource> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            
            this.factory = factory;
        }

        public TSource Resolve(IDiByTypeResolver resolver)
        {
            if (resolver is null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }
            
            return factory.Get();
        }
    }
}
