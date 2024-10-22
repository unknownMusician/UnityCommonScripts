using System;
using System.Collections.Generic;
using System.Linq;
using AreYouFruits.Collections;
using AreYouFruits.Disposables;
using AreYouFruits.Nullability;

namespace AreYouFruits.Events
{
    public sealed class EventHandlersHolder
    {
        private readonly TypedDictionary handlers = new();
        private readonly Dictionary<Type, SortedDictionary<long, Dictionary<Type, Action<IEvent>>>> wrappedHandlers = new();

        private readonly IOrderProvider<Type> orderProvider;

        public EventHandlersHolder(IOrderProvider<Type> orderProvider)
        {
            this.orderProvider = orderProvider;
        }

        public Optional<IDisposable> Subscribe<TEvent>(IEventHandler<TEvent> eventHandler)
            where TEvent : IEvent
        {
            var handlerType = eventHandler.GetType();
            
            long order = orderProvider.GetOrder(handlerType);

            Action<TEvent> handler = eventHandler.Handle;
            Action<IEvent> wrappedHandler = v => eventHandler.Handle((TEvent)v);

            if (!SubscribeInternal(order, handler, wrappedHandler, handlerType))
            {
                return Optional.None();
            }

            return ActionDisposable.Create(() => UnsubscribeInternal<TEvent>(order, handlerType));
        }

        private bool SubscribeInternal<TEvent>(long order, Action<TEvent> handler, Action<IEvent> wrappedHandler, Type handlerType)
            where TEvent : IEvent
        {
            SortedDictionary<long, Dictionary<Type, Action<IEvent>>> typedWrappedHandlers;
            
            if (!handlers.Get<SortedDictionary<long, Dictionary<Type, Action<TEvent>>>>().TryGet(out var typedEventHandlers))
            {
                typedEventHandlers = new();
                handlers.AddVirtual(typedEventHandlers);
                
                typedWrappedHandlers = new();
                wrappedHandlers.Add(typeof(TEvent), typedWrappedHandlers);
            }
            else
            {
                typedWrappedHandlers = wrappedHandlers[typeof(TEvent)];
            }

            var result = typedEventHandlers.GetOrInsertNew(order).TryAdd(handlerType, handler);

            typedWrappedHandlers.GetOrInsertNew(order).TryAdd(handlerType, wrappedHandler);
            
            return result;
        }

        private bool UnsubscribeInternal<TEvent>(long order, Type handlerType)
            where TEvent : IEvent
        {
            if (!handlers.Get<SortedDictionary<long, Dictionary<Type, Action<TEvent>>>>().TryGet(out var typedEventHandlers))
            {
                return false;
            }

            if (!typedEventHandlers.RemoveFromValueDictionaryOrRemoveValue
                <long, Type, Action<TEvent>, Dictionary<Type, Action<TEvent>>>(order, handlerType))
            {
                return false;
            }

            wrappedHandlers[typeof(TEvent)].RemoveFromValueDictionaryOrRemoveValue
                <long, Type, Action<IEvent>, Dictionary<Type, Action<IEvent>>>(order, handlerType);

            if (!typedEventHandlers.Any())
            {
                handlers.RemoveConcrete<SortedDictionary<long, Dictionary<Type, Action<TEvent>>>>();
                wrappedHandlers.Remove(typeof(TEvent));
            }

            return true;
        }

        public IEnumerable<(Type HandlerType, Action<TEvent>)> GetHandlers<TEvent>()
            where TEvent : IEvent
        {
            if (handlers.Get<SortedDictionary<long, Dictionary<Type, Action<TEvent>>>>().TryGet(out var typedEventHandlers))
            {
                return typedEventHandlers.Values
                    .SelectMany(x => x)
                    .Select(x => (x.Key, x.Value));
            }

            return Array.Empty<(Type HandlerType, Action<TEvent>)>();
        }

        public IEnumerable<(Type HandlerType, Action<IEvent> Handler)> GetHandlers(Type eventType)
        {
            if (wrappedHandlers.TryGetValue(eventType, out var typedWrappedEventHandlers))
            {
                return typedWrappedEventHandlers.Values
                    .SelectMany(x => x)
                    .Select(x => (x.Key, x.Value));
            }

            return Array.Empty<(Type, Action<IEvent>)>();
        }

        public Optional<SortedDictionary<long, Dictionary<Type, Action<IEvent>>>> ExposeHandlers(Type eventType)
        {
            if (wrappedHandlers.TryGetValue(eventType, out var typedWrappedEventHandlers))
            {
                return typedWrappedEventHandlers;
            }

            return Optional.None();
        }
    }
}
