using System;
using System.Diagnostics.Contracts;
using AreYouFruits.Nullability;
using AreYouFruits.Ordering;

namespace AreYouFruits.Events
{
    public sealed class HandlerGraphOrderer
    {
        internal readonly GraphOrderer<Type> orderer;

        public HandlerGraphOrderer(GraphOrderer<Type> orderer)
        {
            this.orderer = orderer ?? new();
        }

        public HandlerGraphOrderer() : this(new()) { }

        [Pure]
        public HandlerGraphOrdererHelper<TEvent> ForEvent<TEvent>()
            where TEvent : IEvent
        {
            return new HandlerGraphOrdererHelper<TEvent>(this);
        }
        
        public CachedOrderProvider<Type> ToCached(Optional<int> defaultOrder)
        {
            return orderer.ToCached(defaultOrder);
        }
    }
}
