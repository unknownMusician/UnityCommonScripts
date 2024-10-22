﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using AreYouFruits.Collections;
using AreYouFruits.Nullability;

namespace AreYouFruits.Events
{
    // todo: Add HandlerGroups
    // internal readonly struct HandlersGroupIdentifier
    // {
    //     public object HandlersGroup { get; }
    //
    //     public HandlersGroupIdentifier(object handlersGroup)
    //     {
    //         HandlersGroup = handlersGroup;
    //     }
    // }
    //
    // public sealed class HandlersGroupInfo
    // {
    //     public HashSet<object> Children { get; } = new();
    //     public HashSet<object> Next { get; } = new();
    //     public HashSet<object> Previous { get; } = new();
    // }
    //
    // public sealed class HandlersOrderer
    // {
    //     private readonly HashSet<(Type Min, Type Max)> relations = new();
    //     private readonly Dictionary<object, HandlersGroupInfo> groups = new();
    //     
    //     public void Order(Type previousHandler, Type nextHandler)
    //     {
    //         relations.Add((previousHandler, nextHandler));
    //     }
    //     
    //     public void Order(Type previousHandler, object nextGroup)
    //     {
    //         relations.Add((previousHandler, nextGroup));
    //     }
    //     
    //     public void AssignToGroup(Type handler, object handlerGroup)
    //     {
    //         groups.GetOrInsertNew(handlerGroup).Children.Add(handler);
    //     }
    // }
    
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
        public GraphOrderingHelper<TEvent> ForEvent<TEvent>()
            where TEvent : IEvent
        {
            return new GraphOrderingHelper<TEvent>(this);
        }
        
        public CachedOrderProvider ToCached(Optional<int> defaultOrder)
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