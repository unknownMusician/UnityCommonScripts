using System;
using System.Diagnostics.Contracts;
using AreYouFruits.Ordering;

namespace AreYouFruits.Events
{
    public readonly struct HandlerGraphOrdererHelper<TEvent>
        where TEvent : IEvent
    {
        private readonly HandlerGraphOrderer orderer;

        public HandlerGraphOrdererHelper(HandlerGraphOrderer orderer)
        {
            this.orderer = orderer;
        }

        public bool Order<TPrevious, TNext>()
            where TPrevious : IEventHandler<TEvent>
            where TNext : IEventHandler<TEvent>
        {
            return orderer.orderer.Order(typeof(TPrevious), typeof(TNext));
        }
    }
    public readonly struct HandlerGroupGraphOrdererHelper<TEvent>
        where TEvent : IEvent
    {
        private readonly GroupGraphOrderer<Type> orderer;

        public HandlerGroupGraphOrdererHelper(GroupGraphOrderer<Type> orderer)
        {
            this.orderer = orderer;
        }

        [Pure]
        public HandlerGroupGraphOrdererOrderHandlerHelper<TEvent> Order<TPrevious>()
            where TPrevious : IEventHandler<TEvent>
        {
            return new(orderer.Order(typeof(TPrevious)));
        }

        [Pure]
        public HandlerGroupGraphOrdererOrderGroupHelper<TEvent> Order(HandlerGroupId<TEvent> previousGroup)
        {
            return new(orderer.Order(previousGroup.id));
        }
        
        [Pure]
        public HandlerGroupId<TEvent> Group(object group)
        {
            return new(orderer.Group(group));
        }
    }
    
    public readonly struct HandlerGroupGraphOrdererOrderHandlerHelper<TEvent>
        where TEvent : IEvent
    {
        private readonly GroupGraphOrdererOrderHandlerHelper<Type> helper;

        public HandlerGroupGraphOrdererOrderHandlerHelper(GroupGraphOrdererOrderHandlerHelper<Type> helper)
        {
            this.helper = helper;
        }

        public void Before<TNext>()
            where TNext : IEventHandler<TEvent>
        {
            helper.Before(typeof(TNext));
        }

        public void Before(HandlerGroupId<TEvent> nextGroup)
        {
            helper.Before(nextGroup.id);
        }
    }
    
    public readonly struct HandlerGroupGraphOrdererOrderGroupHelper<TEvent>
        where TEvent : IEvent
    {
        private readonly GroupGraphOrdererOrderGroupHelper<Type> helper;

        public HandlerGroupGraphOrdererOrderGroupHelper(GroupGraphOrdererOrderGroupHelper<Type> helper)
        {
            this.helper = helper;
        }

        public void Before<TNext>()
            where TNext : IEventHandler<TEvent>
        {
            helper.Before(typeof(TNext));
        }

        public void Before(HandlerGroupId<TEvent> nextGroup)
        {
            helper.Before(nextGroup.id);
        }
    }
    
    public readonly struct HandlerGroupId<TEvent>
        where TEvent : IEvent
    {
        internal readonly OrderGroupId<Type> id;

        public object Group => id.Group;

        public HandlerGroupId(OrderGroupId<Type> id)
        {
            this.id = id;
        }

        public HandlerGroupId<TEvent> AssignChild<THandler>()
            where THandler : IEventHandler<TEvent>
        {
            return new(id.AssignChild(typeof(THandler)));
        }

        public HandlerGroupId<TEvent> AssignChild(HandlerGroupId<TEvent> childGroup)
        {
            return new(id.AssignChild(childGroup.id));
        }

        public HandlerGroupId<TEvent> OrderBefore<TNext>()
            where TNext : IEventHandler<TEvent>
        {
            return new(id.OrderBefore(typeof(TNext)));
        }

        public HandlerGroupId<TEvent> OrderBefore(HandlerGroupId<TEvent> nextGroup)
        {
            return new(id.OrderBefore(nextGroup.id));
        }

        public HandlerGroupId<TEvent> OrderAfter<TPrevious>()
            where TPrevious : IEventHandler<TEvent>
        {
            return new(id.OrderAfter(typeof(TPrevious)));
        }

        public HandlerGroupId<TEvent> OrderAfter(HandlerGroupId<TEvent> nextGroup)
        {
            return new(id.OrderAfter(nextGroup.id));
        }
    }
}