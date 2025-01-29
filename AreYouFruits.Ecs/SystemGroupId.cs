using System;
using AreYouFruits.Ordering;

namespace AreYouFruits.Ecs
{
    public readonly struct SystemGroupId
    {
        internal readonly OrderGroupId<Type> id;

        public object Group => id.Group;

        public SystemGroupId(OrderGroupId<Type> id)
        {
            this.id = id;
        }

        public SystemGroupId AssignChild<TSystem>()
            where TSystem : ISystem
        {
            return new SystemGroupId(id.AssignChild(typeof(TSystem)));
        }

        public SystemGroupId AssignChild(SystemGroupId childGroup)
        {
            return new SystemGroupId(id.AssignChild(childGroup.id));
        }

        public SystemGroupId OrderBefore<TNext>()
            where TNext : ISystem
        {
            return new SystemGroupId(id.OrderBefore(typeof(TNext)));
        }

        public SystemGroupId OrderBefore(SystemGroupId nextGroup)
        {
            return new SystemGroupId(id.OrderBefore(nextGroup.id));
        }

        public SystemGroupId OrderAfter<TPrevious>()
            where TPrevious : ISystem
        {
            return new SystemGroupId(id.OrderAfter(typeof(TPrevious)));
        }

        public SystemGroupId OrderAfter(SystemGroupId nextGroup)
        {
            return new SystemGroupId(id.OrderAfter(nextGroup.id));
        }
    }
}