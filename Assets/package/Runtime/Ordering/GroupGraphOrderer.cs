using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using AreYouFruits.Collections;

namespace AreYouFruits.Ordering
{
    public sealed class GroupGraphOrderer<T>
    {
        private readonly Dictionary<object, HashSet<GroupGraphOrdererNode<T>>> groups = new();
        private readonly HashSet<(GroupGraphOrdererNode<T> Min, GroupGraphOrdererNode<T> Max)> relations = new();
        
        [Pure]
        public GroupGraphOrdererOrderHandlerHelper<T> Order(T previous)
        {
            return new GroupGraphOrdererOrderHandlerHelper<T>(this, previous);
        }

        [Pure]
        public GroupGraphOrdererOrderGroupHelper<T> Order(OrderGroupId<T> previousGroup)
        {
            return new GroupGraphOrdererOrderGroupHelper<T>(this, previousGroup);
        }
        
        [Pure]
        public OrderGroupId<T> Group(object group)
        {
            return new OrderGroupId<T>(this, group);
        }

        internal void OrderRaw(GroupGraphOrdererNode<T> previous, GroupGraphOrdererNode<T> next)
        {
            relations.Add((previous, next));
        }

        internal bool AssignToGroupRaw(GroupGraphOrdererNode<T> child, object parentGroup)
        {
            return groups.GetOrInsertNew(parentGroup).Add(child);
        }

        public GraphOrderer<T> ToGraphOrderer()
        {
            var flatGroups = FlattenGroups(groups);

            var graphOrderer = new GraphOrderer<T>();

            var singleValueMinBuffer = new T[1];
            var singleValueMaxBuffer = new T[1];

            foreach (var (min, max) in relations)
            {
                var minValues = GetValues(min, flatGroups, singleValueMinBuffer);
                var maxValues = GetValues(max, flatGroups, singleValueMaxBuffer);
                
                foreach (var minValue in minValues)
                {
                    foreach (var maxValue in maxValues)
                    {
                        graphOrderer.Order(minValue, maxValue);
                    }
                }
            }

            return graphOrderer;
        }

        private static IReadOnlyCollection<T> GetValues(
            GroupGraphOrdererNode<T> node,
            Dictionary<object, HashSet<T>> flatGroups,
            T[] singleValueBuffer
        )
        {
            if (node.IsGroup(out var group))
            {
                return flatGroups[group];
            }

            if (node.IsValue(out var minValue))
            {
                singleValueBuffer[0] = minValue;
                return singleValueBuffer;
            }

            throw new InvalidProgramException();
        }

        private static Dictionary<object, HashSet<T>> FlattenGroups(
            Dictionary<object, HashSet<GroupGraphOrdererNode<T>>> groups
        )
        {
            var groupHierarchy = new Graph<object>();

            foreach (var (parentGroup, groupChildren) in groups)
            {
                groupHierarchy.Add(parentGroup);
                
                foreach (var groupChild in groupChildren)
                {
                    if (groupChild.IsGroup(out var childGroup))
                    {
                        groupHierarchy.Add(parentGroup, childGroup);
                    }
                }
            }

            var flatGroups = new Dictionary<object, HashSet<T>>();

            foreach (var group in groupHierarchy.ToListReversed())
            {
                var flatGroupChildren = new HashSet<T>();
                flatGroups.Add(group, flatGroupChildren);
                
                foreach (var groupChild in groups[group])
                {
                    if (groupChild.IsValue(out var childHandler))
                    {
                        flatGroupChildren.Add(childHandler);
                    }
                    else if (groupChild.IsGroup(out var childGroup))
                    {
                        flatGroupChildren.UnionWith(flatGroups[childGroup]);
                    }
                }
            }

            return flatGroups;
        }
    }
}