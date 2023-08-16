using System;
using System.Collections.Generic;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.TypeResolvers;

namespace AreYouFruits.DependencyInjection.KeyedTypeResolvers
{
    public sealed class KeyedDiContainerCachedKeyWrapper : IDiContainer
    {
        private readonly IDictionary<object, IDiContainer> containers;
        private readonly IDiContainer globalContainer;
        private readonly object key;

        public KeyedDiContainerCachedKeyWrapper(
            IDictionary<object, IDiContainer> containers, IDiContainer globalContainer, object key
        )
        {
            if (containers is null)
            {
                throw new ArgumentNullException(nameof(containers));
            }

            if (globalContainer is null)
            {
                throw new ArgumentNullException(nameof(globalContainer));
            }

            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            this.containers = containers;
            this.globalContainer = globalContainer;
            this.key = key;
        }

        public bool TryResolve(Type type, out object result)
        {
            if (!containers.TryGetValue(key, out IDiContainer container))
            {
                container = globalContainer;
            }

            return container.TryResolve(type, out result);
        }

        public IDiBinder Bind(Type type)
        {
            return GetOrCreateContainer().Bind(type);
        }

        public void Clear()
        {
            if (containers.TryGetValue(key, out IDiContainer container))
            {
                container.Clear();
            }
        }

        public void Clear(Type type)
        {
            if (containers.TryGetValue(key, out IDiContainer container))
            {
                container.Clear(type);
            }
        }
        
        private IDiContainer GetOrCreateContainer()
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