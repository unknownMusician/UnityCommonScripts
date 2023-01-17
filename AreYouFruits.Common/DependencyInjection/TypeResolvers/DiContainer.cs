using System;
using System.Collections.Generic;
using System.Threading;
using AreYouFruits.DependencyInjection.BinderProviders;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Exceptions;

namespace AreYouFruits.DependencyInjection.TypeResolvers
{
    public sealed class DiContainer : IDiContainer
    {
        private readonly Dictionary<int, RecursiveDiByTypeResolver> _aliveThreadResolvers = new Dictionary<int, RecursiveDiByTypeResolver>();
        
        private BindingsHolder _bindingsHolder = new BindingsHolder();

        public IDiBinder Bind(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            
            var binder = new DiBinder(type);

            _bindingsHolder.Add(binder);

            return binder;
        }

        public void Clear()
        {
            _bindingsHolder = new BindingsHolder();
        }

        public void ClearBinding(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            
            _bindingsHolder.TryRemove(type);
        }

        public object Resolve(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            int threadId = Thread.CurrentThread.ManagedThreadId;
            
            if (!_aliveThreadResolvers.TryGetValue(threadId, out RecursiveDiByTypeResolver recursiveTypeResolver))
            {
                recursiveTypeResolver = new RecursiveDiByTypeResolver(_bindingsHolder);
                _aliveThreadResolvers.Add(threadId, recursiveTypeResolver);
            }

            try
            {
                return ResolveThreadIndependent(type, recursiveTypeResolver);
            }
            finally
            {
                _aliveThreadResolvers.Remove(threadId);
            }
        }

        private object ResolveThreadIndependent(Type type, RecursiveDiByTypeResolver recursiveDiByTypeResolver)
        {
            object resolved = recursiveDiByTypeResolver.Resolve(type);

            if (resolved is null)
            {
                throw new InvalidProgramException(nameof(resolved));
            }

            if (!type.IsInstanceOfType(resolved))
            {
                throw new BindingTypeMismatch(type, resolved);
            }

            return resolved;
        }
    }
}