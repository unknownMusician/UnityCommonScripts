using System;
using System.Collections.Generic;
using AreYouFruits.Nullability;

namespace AreYouFruits.Ecs
{
    public struct EventsHolderAccess<TEvent>
        where TEvent : IEcsEvent
    {
        private readonly EventsHolder eventsHolder;
        private Optional<List<TEvent>> events;

        public EventsHolderAccess(EventsHolder eventsHolder)
        {
            this.eventsHolder = eventsHolder;
            events = eventsHolder.GetRaw<TEvent>();
        }
    
        public void Write(TEvent e)
        {
            if (!events.TryGet(out var genericEvents))
            {
                genericEvents = eventsHolder.GetOrCreateRaw<TEvent>();
                events = genericEvents;
            }
        
            genericEvents.Add(e);
        }

        public readonly IReadOnlyList<TEvent> Read()
        {
            if (events.TryGet(out var e))
            {
                return e;
            }

            return Array.Empty<TEvent>();
        }
    }
}