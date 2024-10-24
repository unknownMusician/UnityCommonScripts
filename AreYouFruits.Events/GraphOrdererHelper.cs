using System;
using System.Diagnostics.Contracts;

namespace AreYouFruits.Events
{
    public readonly struct GraphOrdererHelper<TEvent>
        where TEvent : IEvent
    {
        private readonly GraphOrderer orderer;

        public GraphOrdererHelper(GraphOrderer orderer)
        {
            this.orderer = orderer;
        }

        public bool Order<TPrevious, TNext>()
            where TPrevious : IEventHandler<TEvent>
            where TNext : IEventHandler<TEvent>
        {
            return orderer.Order(typeof(TPrevious), typeof(TNext));
        }
    }
    public readonly struct GroupGraphOrdererHelper<TEvent>
        where TEvent : IEvent
    {
        private readonly GroupGraphOrderer orderer;

        public GroupGraphOrdererHelper(GroupGraphOrderer orderer)
        {
            this.orderer = orderer;
        }

        [Pure]
        public GroupGraphOrdererOrderHandlerHelper<TEvent, TPrevious> Order<TPrevious>()
            where TPrevious : IEventHandler<TEvent>
        {
            return new GroupGraphOrdererOrderHandlerHelper<TEvent, TPrevious>(orderer);
        }

        [Pure]
        public GroupGraphOrdererOrderGroupHelper<TEvent> Order(HandlerGroupId<TEvent> previousGroup)
        {
            return new GroupGraphOrdererOrderGroupHelper<TEvent>(orderer, previousGroup);
        }
        
        [Pure]
        public HandlerGroupId<TEvent> Group(object group)
        {
            return new HandlerGroupId<TEvent>(orderer, group);
        }
    }
    
    public readonly struct GroupGraphOrdererOrderHandlerHelper<TEvent, TPreviousHandler>
        where TEvent : IEvent
        where TPreviousHandler : IEventHandler<TEvent>
    {
        private readonly GroupGraphOrderer orderer;

        public GroupGraphOrdererOrderHandlerHelper(GroupGraphOrderer orderer)
        {
            this.orderer = orderer;
        }

        public void Before<TNext>()
            where TNext : IEventHandler<TEvent>
        {
            orderer.OrderRaw(
                GroupHandlersOrdererNode.FromHandler(typeof(TPreviousHandler)),
                GroupHandlersOrdererNode.FromHandler(typeof(TNext))
            );
        }

        public void Before(HandlerGroupId<TEvent> nextGroup)
        {
            orderer.OrderRaw(
                GroupHandlersOrdererNode.FromHandler(typeof(TPreviousHandler)),
                GroupHandlersOrdererNode.FromGroup(nextGroup)
            );
        }
    }
    
    public readonly struct GroupGraphOrdererOrderGroupHelper<TEvent>
        where TEvent : IEvent
    {
        private readonly GroupGraphOrderer orderer;
        private readonly HandlerGroupId<TEvent> previousGroup;

        public GroupGraphOrdererOrderGroupHelper(GroupGraphOrderer orderer, HandlerGroupId<TEvent> previousGroup)
        {
            this.orderer = orderer;
            this.previousGroup = previousGroup;
        }

        public void Before<TNext>()
            where TNext : IEventHandler<TEvent>
        {
            orderer.OrderRaw(
                GroupHandlersOrdererNode.FromGroup(previousGroup),
                GroupHandlersOrdererNode.FromHandler(typeof(TNext))
            );
        }

        public void Before(HandlerGroupId<TEvent> nextGroup)
        {
            orderer.OrderRaw(
                GroupHandlersOrdererNode.FromGroup(previousGroup),
                GroupHandlersOrdererNode.FromGroup(nextGroup)
            );
        }
    }
    
    public readonly struct HandlerGroupId<TEvent>
        where TEvent : IEvent
    {
        private readonly GroupGraphOrderer orderer;
        
        public object Group { get; }

        public HandlerGroupId(GroupGraphOrderer orderer, object group)
        {
            this.orderer = orderer;
            Group = group;
        }

        public HandlerGroupId<TEvent> AssignChild<THandler>()
            where THandler : IEventHandler<TEvent>
        {
            orderer.AssignToGroupRaw(GroupHandlersOrdererNode.FromHandler(typeof(THandler)), Group);
            
            return this;
        }

        public HandlerGroupId<TEvent> AssignChild(HandlerGroupId<TEvent> childGroup)
        {
            orderer.AssignToGroupRaw(GroupHandlersOrdererNode.FromGroup(childGroup), Group);
            
            return this;
        }

        public HandlerGroupId<TEvent> OrderBefore<TNext>()
            where TNext : IEventHandler<TEvent>
        {
            orderer.OrderRaw(
                GroupHandlersOrdererNode.FromGroup(this),
                GroupHandlersOrdererNode.FromHandler(typeof(TNext))
            );
            
            return this;
        }

        public HandlerGroupId<TEvent> OrderBefore(HandlerGroupId<TEvent> nextGroup)
        {
            orderer.OrderRaw(
                GroupHandlersOrdererNode.FromGroup(this),
                GroupHandlersOrdererNode.FromGroup(nextGroup)
            );
            
            return this;
        }

        public HandlerGroupId<TEvent> OrderAfter<TPrevious>()
            where TPrevious : IEventHandler<TEvent>
        {
            orderer.OrderRaw(
                GroupHandlersOrdererNode.FromHandler(typeof(TPrevious)),
                GroupHandlersOrdererNode.FromGroup(this)
            );
            
            return this;
        }

        public HandlerGroupId<TEvent> OrderAfter(HandlerGroupId<TEvent> nextGroup)
        {
            orderer.OrderRaw(
                GroupHandlersOrdererNode.FromGroup(nextGroup),
                GroupHandlersOrdererNode.FromGroup(this)
            );
            
            return this;
        }
    }
}