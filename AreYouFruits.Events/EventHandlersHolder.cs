using System;
using System.Collections.Generic;
using System.Linq;

namespace AreYouFruits.EventBus
{
    public sealed class EventHandlersHolder
    {
        private readonly TypedDictionary handlers = new();

        private readonly HandlersOrderer handlersOrderer;

        public EventHandlersHolder(HandlersOrderer handlersOrderer)
        {
            this.handlersOrderer = handlersOrderer;
        }

        public bool Subscribe<TEvent>(Type callerType, Action<TEvent> eventHandler)
            where TEvent : IEvent
        {
            if (!handlers.Get<SortedDictionary<long, Action<TEvent>>>().TryGet(out var typedEventHandlers))
            {
                typedEventHandlers = new();
                handlers.Add(typedEventHandlers);
            }

            long order = handlersOrderer.GetOrder(callerType, typeof(TEvent));
            return typedEventHandlers.TryAdd(order, eventHandler);
        }

        public bool Unsubscribe<TEvent>(Type callerType, Action<TEvent> eventHandler)
            where TEvent : IEvent
        {
            if (!handlers.Get<SortedDictionary<long, Action<TEvent>>>().TryGet(out var typedEventHandlers))
            {
                return false;
            }

            long order = handlersOrderer.GetOrder(callerType, typeof(TEvent));

            if (typedEventHandlers.TryGetValue(order, out var savedEventHandler) && (eventHandler != savedEventHandler))
            {
                return false;
            }

            if (!typedEventHandlers.Remove(order))
            {
                return false;
            }

            if (!typedEventHandlers.Any())
            {
                handlers.Remove<SortedDictionary<long, Action<TEvent>>>();
            }

            return true;
        }

        public Action<TEvent>[] GetHandlers<TEvent>()
        {
            if (handlers.Get<SortedDictionary<long, Action<TEvent>>>().TryGet(out var typedEventHandlers))
            {
                return typedEventHandlers.Values.ToArray();
            }

            return Array.Empty<Action<TEvent>>();
        }
    }
}
