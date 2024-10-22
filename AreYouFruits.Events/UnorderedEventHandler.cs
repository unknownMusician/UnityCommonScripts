using System;

namespace AreYouFruits.Events
{
    public sealed class UnorderedEventHandler<TEvent> : IEventHandler<TEvent>
        where TEvent : IEvent
    {
        private readonly Action<TEvent> handler;

        public UnorderedEventHandler(Action<TEvent> handler)
        {
            this.handler = handler;
        }

        public void Handle(TEvent @event)
        {
            handler(@event);
        }
    }
}
