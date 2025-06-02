using System;
using System.Collections.Generic;
using System.Linq;
using AreYouFruits.Collections;

namespace AreYouFruits.Ordering
{
    public sealed class Graph<T>
    {
        private readonly Dictionary<T, HashSet<T>> forward = new();
        private readonly Dictionary<T, HashSet<T>> backward = new();
        private readonly HashSet<T> nodes = new();

        public bool Add(T source, T destination)
        {
            if (!nodes.Add(source) && !nodes.Add(destination))
            {
                return false;
            }
            
            if (!forward.GetOrInsertNew(source).Add(destination))
            {
                return false;
            }

            backward.GetOrInsertNew(destination).Add(source);

            return true;
        }

        public bool Add(T node)
        {
            return nodes.Add(node);
        }

        public List<T> ToList()
        {
            return ToList(backward, nodes);
        }

        public List<T> ToListReversed()
        {
            return ToList(forward, nodes);
        }

        private static List<T> ToList(Dictionary<T, HashSet<T>> inverted, HashSet<T> nodes)
        {
            var maxToMin = inverted.ToDictionary(
                p => p.Key,
                p => p.Value.ToHashSet()
            );

            var orderedSet = new HashSet<T>();
            var ordered = new List<T>();

            while (maxToMin.Any())
            {
                var min = GetMostMin(maxToMin, out var max);

                if (orderedSet.Add(min))
                {
                    ordered.Add(min);
                }

                if (maxToMin.TryGetValue(max, out var mins))
                {
                    mins.Remove(min);
                    
                    if (mins.Count is 0)
                    {
                        if (orderedSet.Add(max))
                        {
                            ordered.Add(max);
                        }

                        maxToMin.Remove(max);
                    }
                }
            }
            
            foreach (var node in nodes)
            {
                if (orderedSet.Add(node))
                {
                    ordered.Add(node);
                }
            }

            return ordered;
        }

        private static T GetMostMin(IReadOnlyDictionary<T, HashSet<T>> maxToMin, out T maxToThat)
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

            throw new InvalidOperationException($"The graph contains circular dependencies. History: {string.Join(" -> ", visited)}. Cycle: {max}.");
        }
    }
}