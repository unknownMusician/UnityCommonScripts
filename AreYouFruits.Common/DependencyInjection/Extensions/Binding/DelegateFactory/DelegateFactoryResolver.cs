using System;
using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection.Extensions.Binding.DelegateFactory
{
    public sealed class DelegateFactoryResolver<TSource> : IResolver<TSource>
    {
        private readonly Func<TSource> factory;

        public DelegateFactoryResolver(Func<TSource> factory)
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
            
            return factory();
        }
    }
}
