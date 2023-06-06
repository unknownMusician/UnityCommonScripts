using System;
using System.Collections.Generic;
using AreYouFruits.Common.DependencyInjection.BinderProviders;
using AreYouFruits.Common.DependencyInjection.Binders;
using AreYouFruits.Common.DependencyInjection.Exceptions;
using AreYouFruits.Common.DependencyInjection.Resolvers;

namespace AreYouFruits.Common.DependencyInjection.TypeResolvers
{
    public sealed class RecursiveDiByTypeResolver : IDiByTypeResolver
    {
        private readonly IBindingsProvider bindingsProvider;
        private readonly HashSet<Type> resolvingTypes;

        public RecursiveDiByTypeResolver(IBindingsProvider bindingsProvider)
        {
            if (bindingsProvider is null)
            {
                throw new ArgumentNullException(nameof(bindingsProvider));
            }
            
            this.bindingsProvider = bindingsProvider;
            resolvingTypes = new HashSet<Type>();
        }

        public bool TryResolve(Type type, out object result)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            
            if (!resolvingTypes.Add(type))
            {
                throw new RecursiveBindingException();
            }

            object resolved;

            try
            {
                if (!bindingsProvider.TryGet(type, out IDiBinding binding))
                {
                    result = null!;
                    return false;
                }

                resolved = Resolve(binding.Resolver);
            }
            finally
            {
                resolvingTypes.Remove(type);
            }

            if (resolved is null)
            {
                throw new ArgumentNullException(nameof(resolved), $"Bound object of type {type} is null. This is not permitted.");
            }

            if (!type.IsInstanceOfType(resolved))
            {
                throw new BindingTypeMismatch(type, resolved);
            }

            result = resolved;
            return true;
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