using System;
using System.Collections.Generic;

namespace AreYouFruits.Ecs
{
    public sealed class SystemDataUsage
    {
        private readonly HashSet<Type> events = new();
        private readonly HashSet<Type> resources = new();

        public IReadOnlyCollection<Type> Events => events;
        public IReadOnlyCollection<Type> Resources => resources;

        public SystemDataUsage Event<T>()
            where T : IEcsEvent
        {
            events.Add(typeof(T));

            return this;
        }

        public SystemDataUsage Resource<T>()
            where T : IResource
        {
            resources.Add(typeof(T));

            return this;
        }
    }
}