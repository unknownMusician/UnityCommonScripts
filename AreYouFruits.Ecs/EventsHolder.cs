using System;
using System.Collections.Generic;
using AreYouFruits.Nullability;

namespace AreYouFruits.Ecs
{
    public sealed class EventsHolder
    {
        internal readonly Dictionary<Type, object> events = new();
    
        public EventsHolderAccess<TEvent> Of<TEvent>()
            where TEvent : IEcsEvent
        {
            return new EventsHolderAccess<TEvent>(this);
        }

        internal Optional<List<TEvent>> GetRaw<TEvent>()
            where TEvent : IEcsEvent
        {
            if (events.TryGetValue(typeof(TEvent), out var eventsAsObject))
            {
                return (List<TEvent>)eventsAsObject;
            }

            return Optional.None();
        }

        internal List<TEvent> CreateRaw<TEvent>()
            where TEvent : IEcsEvent
        {
            var genericEvents = new List<TEvent>();
        
            events[typeof(TEvent)] = genericEvents;
        
            return genericEvents;
        }

        internal void Clear()
        {
            // todo: Maybe clear each separately to not reallocate?
            events.Clear();
        }
    }
}