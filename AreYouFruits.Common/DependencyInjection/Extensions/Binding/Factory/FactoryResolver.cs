using System;
using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection.Extensions.Binding.Factory
{
    public sealed class FactoryResolver<TSource> : IResolver<TSource>
    {
        private readonly Func<TSource> _factory;

        public FactoryResolver(Func<TSource> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            
            _factory = factory;
        }

        public TSource Resolve(IDiByTypeResolver resolver)
        {
            if (resolver is null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }
            
            return _factory();
        }
    }
}
