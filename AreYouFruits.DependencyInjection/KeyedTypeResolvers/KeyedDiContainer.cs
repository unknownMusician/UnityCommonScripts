using System;
using System.Collections.Generic;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.TypeResolvers;

namespace AreYouFruits.DependencyInjection.KeyedTypeResolvers
{
    public sealed class KeyedDiContainer : IKeyedDiContainer
    {
        private readonly Dictionary<object, IDiContainer> containers;
        private readonly IDiContainer globalContainer;

        public KeyedDiContainer()
        {
            containers = new Dictionary<object, IDiContainer>();
            globalContainer = new DiContainer();
        }

        public bool TryResolve(Type type, object key, out object result)
        {
            if (!containers.TryGetValue(key, out IDiContainer container))
            {
                container = globalContainer;
            }

            return container.TryResolve(type, out result);
        }

        public IDiBinder Bind(Type type, object key)
        {
            return GetOrCreateContainer(key).Bind(type);
        }

        public IDiBinder Bind(Type type)
        {
            return globalContainer.Bind(type);
        }

        public void Clear()
        {
            containers.Clear();
            ClearGlobal();
        }

        public void Clear(Type type, object key)
        {
            if (containers.TryGetValue(key, out IDiContainer container))
            {
                container.Clear(type);
            }
        }

        public void Clear(Type type)
        {
            foreach ((_, IDiContainer container) in containers)
            {
                container.Clear(type);
            }

            ClearGlobal(type);
        }

        public IDiContainer For(object key)
        {
            return new KeyedDiContainerCachedKeyWrapper(containers, globalContainer, key);
        }

        public void Clear(object key)
        {
            if (containers.TryGetValue(key, out IDiContainer container))
            {
                container.Clear();
            }
        }

        public void ClearGlobal()
        {
            globalContainer.Clear();
        }

        public void ClearGlobal(Type type)
        {
            globalContainer.Clear(type);
        }

        public bool TryResolve(Type type, out object result)
        {
            return globalContainer.TryResolve(type, out result);
        }
        
        private IDiContainer GetOrCreateContainer(object key)
        {
            if (!containers.TryGetValue(key, out IDiContainer container))
            {
                container = new DiContainer();
                containers.Add(key, container);
            }

            return container;
        }
    }
}