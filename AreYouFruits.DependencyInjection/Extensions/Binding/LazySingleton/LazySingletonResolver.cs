using System;
using AreYouFruits.DependencyInjection.Extensions.Binding.Factory;
using AreYouFruits.DependencyInjection.Resolvers;
using AreYouFruits.DependencyInjection.TypeResolvers;

namespace AreYouFruits.DependencyInjection.Extensions.Binding.LazySingleton
{
    public sealed class LazySingletonResolver<TDestination> : IResolver<TDestination>
    {
        private readonly IFactory<TDestination> factory;
        
        private bool containsValue;
        private TDestination singleton;

        public LazySingletonResolver(IFactory<TDestination> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            
            this.factory = factory;
            singleton = default!;
        }

        public TDestination Resolve(IDiByTypeResolver resolver)
        {
            if (resolver is null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }

            if (!containsValue)
            {
                singleton = factory.Get();
                containsValue = true;
            }
            
            return singleton;
        }
    }
}