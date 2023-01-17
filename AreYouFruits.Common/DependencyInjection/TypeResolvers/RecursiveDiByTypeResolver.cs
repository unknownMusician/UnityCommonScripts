using System;
using System.Collections.Generic;
using AreYouFruits.DependencyInjection.BinderProviders;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Exceptions;
using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection.TypeResolvers
{
    public sealed class RecursiveDiByTypeResolver : IDiByTypeResolver
    {
        private readonly IBindingsProvider _bindingsProvider;
        private readonly HashSet<Type> _resolvingTypes;

        public RecursiveDiByTypeResolver(IBindingsProvider bindingsProvider)
        {
            if (bindingsProvider is null)
            {
                throw new ArgumentNullException(nameof(bindingsProvider));
            }
            
            _bindingsProvider = bindingsProvider;
            _resolvingTypes = new HashSet<Type>();
        }

        public object Resolve(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            
            if (!_resolvingTypes.Add(type))
            {
                throw new RecursiveBindingException();
            }

            object resolved;

            try
            {
                IDiBinding binding = _bindingsProvider.Get(type);

                resolved = Resolve(binding.Resolver);
            }
            finally
            {
                _resolvingTypes.Remove(type);
            }

            if (!type.IsInstanceOfType(resolved))
            {
                throw new BindingTypeMismatch(type, resolved);
            }

            return resolved;
        }

        private object Resolve(IResolver<object> resolver)
        {
            if (resolver is null)
            {
                throw new UnfinishedBindingException();
            }

            return resolver.Resolve(this);
        }
    }
}