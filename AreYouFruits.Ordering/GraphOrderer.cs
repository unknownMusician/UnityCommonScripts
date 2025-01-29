using System;
using System.Collections.Generic;
using System.Linq;
using AreYouFruits.Collections;
using AreYouFruits.Nullability;

namespace AreYouFruits.Ordering
{
    public sealed class GraphOrderer<T>
    {
        private readonly HashSet<(T Min, T Max)> relations = new();

        public IReadOnlyCollection<(T Min, T Max)> Relations => relations;

        public bool Order(T previous, T next)
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

        public CachedOrderProvider<T> ToCached(Optional<int> defaultOrder)
            // todo: use Graph instead
        {
            var maxToMin = new Dictionary<T, List<T>>();

            foreach (var (min, max) in Relations)
            {
                maxToMin.GetOrInsertNew(max).Add(min);
            }

            var orderedValuesSet = new HashSet<T>();
            var orderedValues = new List<T>();

            while (maxToMin.Any())
            {
                var min = GetMostMin(maxToMin, out var max);

                if (orderedValuesSet.Add(min))
                {
                    orderedValues.Add(min);
                }

                if (maxToMin.TryGetValue(max, out var mins))
                {
                    mins.Remove(min);

                    if (mins.Count is 0)
                    {
                        if (orderedValuesSet.Add(max))
                        {
                            orderedValues.Add(max);
                        }

                        maxToMin.Remove(max);
                    }
                }
            }

            var orders = new Dictionary<T, int>();

            for (var i = 0; i < orderedValues.Count; i++)
            {
                orders.Add(orderedValues[i], i);
            }

            return CachedOrderProvider.From(
                Optional.Some<IReadOnlyDictionary<T, int>>(orders),
                defaultOrder
            );
        }

        private static T GetMostMin(IReadOnlyDictionary<T, List<T>> maxToMin, out T maxToThat)
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

            throw new InvalidOperationException(
                $"The orderer contains circular dependencies. History: {string.Join(" -> ", visited)}. Cycle: {max}.");
        }
    }
}