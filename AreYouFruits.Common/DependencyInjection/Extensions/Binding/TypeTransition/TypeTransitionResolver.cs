using System;
using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection.Extensions.Binding.TypeTransition
{
    public sealed class TypeTransitionResolver<TSource, TDestination> : IResolver<TSource>
        where TDestination : TSource
    {
        public TSource Resolve(IDiByTypeResolver resolver)
        {
            if (resolver is null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }

            return resolver.Resolve<TDestination>();
        }
    }

    public sealed class TypeTransitionResolver : IResolver<object>
    {
        public readonly Type Type;

        public TypeTransitionResolver(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            
            Type = type;
        }

        public object Resolve(IDiByTypeResolver resolver)
        {
            if (resolver is null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }
            
            return resolver.Resolve(Type);
        }
    }
}
