using System;
using System.Diagnostics.Contracts;
using AreYouFruits.Ordering;

namespace AreYouFruits.Ecs
{
    public sealed class SystemsGroupGraphOrderer
    {
        private readonly GroupGraphOrderer<Type> orderer = new();
    
        [Pure]
        public SystemsGroupGraphOrdererOrderHandlerHelper Order<TPrevious>()
            where TPrevious : ISystem
        {
            return new SystemsGroupGraphOrdererOrderHandlerHelper(orderer.Order(typeof(TPrevious)));
        }

        [Pure]
        public SystemsGroupGraphOrdererOrderGroupHelper Order(SystemGroupId previousGroup)
        {
            return new SystemsGroupGraphOrdererOrderGroupHelper(orderer.Order(previousGroup.id));
        }
        
        [Pure]
        public SystemGroupId Group(object group)
        {
            return new SystemGroupId(orderer.Group(group));
        }

        public SystemsGraphOrderer ToGraphOrderer()
        {
            return new SystemsGraphOrderer(orderer.ToGraphOrderer());
        }
    }
}