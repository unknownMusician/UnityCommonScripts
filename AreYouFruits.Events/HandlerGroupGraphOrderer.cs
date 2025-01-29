using System;
using System.Diagnostics.Contracts;
using AreYouFruits.Ordering;

namespace AreYouFruits.Events
{
    public sealed class HandlerGroupGraphOrderer
    {
        private readonly GroupGraphOrderer<Type> orderer = new();
        
        [Pure]
        public HandlerGroupGraphOrdererHelper<TEvent> ForEvent<TEvent>()
            where TEvent : IEvent
        {
            return new HandlerGroupGraphOrdererHelper<TEvent>(orderer);
        }

        public HandlerGraphOrderer ToGraphOrderer()
        {
            return new(orderer.ToGraphOrderer());
        }
    }
}