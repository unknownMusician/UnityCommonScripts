using System;
using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection.Extensions.Binding.Singleton
{
    public sealed class SingletonResolver<TSource> : IResolver<TSource>
    {
        private readonly TSource _singleton;

        public SingletonResolver(TSource singleton)
        {
            if (singleton is null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }
            
            _singleton = singleton;
        }

        public TSource Resolve(IDiByTypeResolver resolver)
        {
            if (resolver is null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }
            
            return _singleton;
        }
    }
}