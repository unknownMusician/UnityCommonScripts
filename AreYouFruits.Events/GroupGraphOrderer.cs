using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using AreYouFruits.Collections;

namespace AreYouFruits.Events
{
    public sealed class GroupGraphOrderer
    {
        private readonly Dictionary<object, HashSet<GroupHandlersOrdererNode>> groups = new();
        private readonly HashSet<(GroupHandlersOrdererNode Min, GroupHandlersOrdererNode Max)> relations = new();
        
        [Pure]
        public GroupGraphOrdererHelper<TEvent> ForEvent<TEvent>()
            where TEvent : IEvent
        {
            return new GroupGraphOrdererHelper<TEvent>(this);
        }

        internal void OrderRaw(GroupHandlersOrdererNode previous, GroupHandlersOrdererNode next)
        {
            relations.Add((previous, next));
        }

        internal bool AssignToGroupRaw(GroupHandlersOrdererNode child, object parentGroup)
        {
            return groups.GetOrInsertNew(parentGroup).Add(child);
        }

        public GraphOrderer ToGraphOrderer()
        {
            var flatGroups = FlattenGroups(groups);

            var graphOrderer = new GraphOrderer();

            var singleTypeMinBuffer = new Type[1];
            var singleTypeMaxBuffer = new Type[1];

            foreach (var (min, max) in relations)
            {
                var minTypes = GetTypes(min, flatGroups, singleTypeMinBuffer);
                var maxTypes = GetTypes(max, flatGroups, singleTypeMaxBuffer);
                
                foreach (var minType in minTypes)
                {
                    foreach (var maxType in maxTypes)
                    {
                        graphOrderer.Order(minType, maxType);
                    }
                }
            }

            return graphOrderer;
        }

        private static IReadOnlyCollection<Type> GetTypes(
            GroupHandlersOrdererNode node,
            Dictionary<object, HashSet<Type>> flatGroups,
            Type[] singleTypeBuffer
        )
        {
            if (node.IsGroup(out var group))
            {
                return flatGroups[group];
            }

            if (node.IsHandler(out var minHandler))
            {
                singleTypeBuffer[0] = minHandler;
                return singleTypeBuffer;
            }

            throw new InvalidProgramException();
        }

        private static Dictionary<object, HashSet<Type>> FlattenGroups(
            Dictionary<object, HashSet<GroupHandlersOrdererNode>> groups
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

            var flatGroups = new Dictionary<object, HashSet<Type>>();

            foreach (var group in groupHierarchy.ToListReversed())
            {
                var flatGroupChildren = new HashSet<Type>();
                flatGroups.Add(group, flatGroupChildren);
                
                foreach (var groupChild in groups[group])
                {
                    if (groupChild.IsHandler(out var childHandler))
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