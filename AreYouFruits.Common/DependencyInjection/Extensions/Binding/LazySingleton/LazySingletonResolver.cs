using System;
using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection.Extensions.Binding.LazySingleton
{
    public sealed class LazySingletonResolver<TDestination> : IResolver<TDestination>
    {
        private readonly Func<TDestination> _factory;
        
        private bool _containsValue;
        private TDestination _singleton;

        public LazySingletonResolver(Func<TDestination> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            
            _factory = factory;
        }

        public TDestination Resolve(IDiByTypeResolver resolver)
        {
            if (resolver is null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }

            if (!_containsValue)
            {
                _singleton = _factory();
                _containsValue = true;
            }
            
            return _singleton;
        }
    }
}