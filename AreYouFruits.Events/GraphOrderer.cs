using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using AreYouFruits.Collections;
using AreYouFruits.Nullability;

namespace AreYouFruits.Events
{
    public sealed class GraphOrderer
    {
        private readonly HashSet<(Type Min, Type Max)> relations = new();

        public IReadOnlyCollection<(Type Min, Type Max)> Relations => relations;

        public bool Order(Type previous, Type next)
        {
            if (relations.Contains((previous, next)))
            {
                return true;
            }

            if (relations.Contains((next, previous)))
            {
                return false;
            }

            relations.Add((previous, next));
            return true;
        }
        
        [Pure]
        public GraphOrdererHelper<TEvent> ForEvent<TEvent>()
            where TEvent : IEvent
        {
            return new GraphOrdererHelper<TEvent>(this);
        }
        
        public CachedOrderProvider ToCached(Optional<int> defaultOrder)
            // todo: use Graph instead
        {
            var maxToMin = new Dictionary<Type, List<Type>>();

            foreach (var (min, max) in Relations)
            {
                maxToMin.GetOrInsertNew(max).Add(min);
            }
            
            var orderedTypesSet = new HashSet<Type>();
            var orderedTypes = new List<Type>();

            while (maxToMin.Any())
            {
                var min = GetMostMin(maxToMin, out var max);

                if (orderedTypesSet.Add(min))
                {
                    orderedTypes.Add(min);
                }

                if (maxToMin.TryGetValue(max, out var mins))
                {
                    mins.Remove(min);
                    
                    if (mins.Count is 0)
                    {
                        if (orderedTypesSet.Add(max))
                        {
                            orderedTypes.Add(max);
                        }

                        maxToMin.Remove(max);
                    }
                }
            }
            
            var orders = new Dictionary<Type, int>();

            for (var i = 0; i < orderedTypes.Count; i++)
            {
                orders.Add(orderedTypes[i], i);
            }
            
            return new CachedOrderProvider(
                Optional.Some<IReadOnlyDictionary<Type, int>>(orders),
                defaultOrder
            );
        }

        private static T GetMostMin<T>(IReadOnlyDictionary<T, List<T>> maxToMin, out T maxToThat)
        {
            var visited = new HashSet<T>();
            
            var (max, mins) = maxToMin.First();
            
            while (visited.Add(max))
            {
                var min = mins.First();

                if (!maxToMin.TryGetValue(min, out mins))
                {
                    maxToThat = max;
                    return min;
                }

                max = min;
            }

            throw new InvalidOperationException($"The orderer contains circular dependencies. History: {string.Join(" -> ", visited)}. Cycle: {max}.");
        }
    }
}
