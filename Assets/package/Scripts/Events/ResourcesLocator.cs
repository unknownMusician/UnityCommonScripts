using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AreYouFruits.Nullability;

namespace AreYouFruits.Events
{
    public static class ResourcesLocator
    {
        private static readonly HashSet<Type> ReadonlyTypes = new();
        private static readonly TypedDictionary Resourses = new();
        
        public static Optional<IResourcesDebugger> Debugger { get; set; }

        public static TResource Get<TResource>()
        {
            return TryGet<TResource>().GetOrThrow();
        }

        public static Optional<TResource> TryGet<TResource>()
        {
            var resource = Resourses.Get<TResource>();

            if (resource.TryGet(out var notNullResource) && Debugger.TryGet(out var debugger))
            {
                debugger.HandleResourceAccessed(
                    notNullResource.GetType(),
                    typeof(TResource),
                    ReadonlyTypes.Contains(typeof(TResource))
                );
            }
            
            return resource;
        }
        
        public static bool Add(object resource)
        {
            var type = resource.GetType();

            if (Resourses.Contains(type))
            {
                return false;
            }

            var readonlyInterfaces = type
                .GetInterfaces()
                .Where(i => i.GetCustomAttribute<ReadonlyResourceAccessAttribute>() is not null).ToArray();

            foreach (var readonlyInterface in readonlyInterfaces)
            {
                if (Resourses.Contains(readonlyInterface))
                {
                    return false;
                }
            }
            
            if (type.GetCustomAttribute<ReadonlyResourceAccessAttribute>() is not null)
            {
                ReadonlyTypes.Add(type);
            }
            
            Resourses.AddVirtual(resource);

            foreach (var readonlyInterface in readonlyInterfaces)
            {
                ReadonlyTypes.Add(readonlyInterface);
                Resourses.AddConcrete(resource, readonlyInterface);
            }
            
            return true;
        }

        public static void Clear()
        {
            ReadonlyTypes.Clear();
            Resourses.Clear();
        }
    }
}