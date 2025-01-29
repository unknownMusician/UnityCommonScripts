using System;
using System.Collections.Generic;
using AreYouFruits.Nullability;

namespace AreYouFruits.Ecs
{
    public sealed class ResourcesHolder
    {
        private readonly Dictionary<Type, IResource> resources = new();
    
        public void Set<T>(T resource)
            where T : IResource
        {
            resources[typeof(T)] = resource;
        }

        public Optional<T> TryGet<T>()
            where T : IResource
        {
            if (resources.TryGetValue(typeof(T), out var value))
            {
                return (T)value;
            }

            return Optional.None();
        }

        public T Get<T>()
            where T : IResource
        {
            return TryGet<T>().GetOrThrow();
        }

        public void Clear()
        {
            resources.Clear();
        }
    }
}