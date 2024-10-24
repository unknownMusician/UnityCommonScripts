﻿using System;
using System.Collections.Generic;
using System.Threading;
using AreYouFruits.DependencyInjection.BinderProviders;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Exceptions;

namespace AreYouFruits.DependencyInjection.TypeResolvers
{
    public sealed class DiContainer : IDiContainer
    {
        private readonly Dictionary<int, RecursiveDiByTypeResolver> aliveThreadResolvers = new();
        
        private BindingsHolder bindingsHolder = new();

        public IDiBinder Bind(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            
            var binder = new DiBinder(type);

            bindingsHolder.Add(binder);

            return binder;
        }

        public void Clear()
        {
            bindingsHolder = new BindingsHolder();
        }

        public void Clear(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            
            bindingsHolder.TryRemove(type);
        }

        public bool TryResolve(Type type, out object result)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var threadId = Thread.CurrentThread.ManagedThreadId;
            
            if (!aliveThreadResolvers.TryGetValue(threadId, out var recursiveTypeResolver))
            {
                recursiveTypeResolver = new RecursiveDiByTypeResolver(bindingsHolder);
                aliveThreadResolvers.Add(threadId, recursiveTypeResolver);
            }

            try
            {
                return ResolveThreadIndependent(type, recursiveTypeResolver, out result);
            }
            finally
            {
                aliveThreadResolvers.Remove(threadId);
            }
        }

        private bool ResolveThreadIndependent(Type type, IDiByTypeResolver diByTypeResolver, out object result)
        {
            if (!diByTypeResolver.TryResolve(type, out var potentialResult))
            {
                result = null!;
                return false;
            }

            if (potentialResult is null)
            {
                throw new InvalidProgramException(nameof(potentialResult));
            }

            if (!type.IsInstanceOfType(potentialResult))
            {
                throw new BindingTypeMismatch(type, potentialResult);
            }

            result = potentialResult;
            return true;
        }
    }
}