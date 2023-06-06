using System;
using AreYouFruits.Common.DependencyInjection.Resolvers;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.DelegateLazySingleton
{
    public sealed class DelegateLazySingletonResolver<TDestination> : IResolver<TDestination>
    {
        private readonly Func<TDestination> factory;
        
        private bool containsValue;
        private TDestination singleton;

        public DelegateLazySingletonResolver(Func<TDestination> factory)
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
                singleton = factory();
                containsValue = true;
            }
            
            return singleton;
        }
    }
}