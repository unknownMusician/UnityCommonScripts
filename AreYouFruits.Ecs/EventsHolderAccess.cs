using System;
using System.Collections.Generic;
using AreYouFruits.Nullability;

namespace AreYouFruits.Ecs
{
    public readonly struct EventsHolderAccess<TEvent>
        where TEvent : IEcsEvent
    {
        private readonly EventsHolder eventsHolder;
        private readonly Optional<List<TEvent>> events;

        public EventsHolderAccess(EventsHolder eventsHolder)
        {
            this.eventsHolder = eventsHolder;
            events = eventsHolder.GetRaw<TEvent>();
        }
    
        public readonly void Write(TEvent e)
        {
            if (!events.TryGet(out var genericEvents))
            {
                genericEvents = eventsHolder.CreateRaw<TEvent>();
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