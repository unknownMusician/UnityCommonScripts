using System;
using System.Collections.Generic;
using System.Linq;
using AreYouFruits.Disposables;
using AreYouFruits.Nullability;

namespace AreYouFruits.Events
{
    public sealed class EventBus
        // todo: Try-catch calls to external code.
        // todo: Add external logger.
        // todo: Add safe iteration and allow to change handlers collection.
        // todo? Add handler subscribing that causes the handler to handle only its type, no children.
    {
        private readonly Dictionary<Type, Optional<EventHandlersIterator>> cachedIterators = new();
        
        private readonly EventHandlersHolder eventHandlersHolder;
        private readonly Optional<IHandlersDebugger> handlersDebugger;

        private int subscribedInterfacesCount;
        private int subscribedNonSealedClassesCount;
        
        public EventBus(IOrderProvider<Type> orderProvider)
        {
            eventHandlersHolder = new(orderProvider);
        }

        public EventBus(IOrderProvider<Type> orderProvider, IHandlersDebugger handlersDebugger)
        {
            eventHandlersHolder = new(orderProvider);
            this.handlersDebugger = Optional.Some(handlersDebugger);
        }
        
        public Optional<IDisposable> Subscribe<TEvent>(IEventHandler<TEvent> eventHandler)
            where TEvent : IEvent
        {
            if (!eventHandlersHolder.Subscribe(eventHandler).TryGet(out var subscription))
            {
                return Optional.None();
            }
            
            cachedIterators.Clear();
            if (typeof(TEvent).IsInterface)
            {
                subscribedInterfacesCount++;
            }
            else if (!typeof(TEvent).IsSealed)
            {
                subscribedNonSealedClassesCount++;
            }

            return ActionDisposable.Create(() =>
            {
                cachedIterators.Clear();
                subscription.Dispose();
                
                if (typeof(TEvent).IsInterface)
                {
                    subscribedInterfacesCount--;
                }
                else if (!typeof(TEvent).IsSealed)
                {
                    subscribedNonSealedClassesCount--;
                }
            });
        }

        public Optional<IDisposable> Subscribe<TEvent>(Action<TEvent> eventHandler)
            where TEvent : IEvent
        {
            return Subscribe(new UnorderedEventHandler<TEvent>(eventHandler));
        }

        public bool Invoke<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            if (cachedIterators.TryGetValue(typeof(TEvent), out var iterator))
            {
                if (!iterator.TryGet(out var notNullIterator))
                {
                    return InvokeWithoutBaseTypes(@event);
                }

                notNullIterator.Iterate(@event);
                return true;
            }

            if (!GetParentTypes(@event).TryGet(out var types))
            {
                return InvokeConcrete(@event);
            }

            List<SortedDictionary<long, Dictionary<Type, Action<IEvent>>>> handlers = null;

            foreach (var type in types)
            {
                if (eventHandlersHolder.ExposeHandlers(type).TryGet(out var typeHandlers))
                {
                    handlers ??= new();
                    handlers.Add(typeHandlers);
                }
            }

            if (handlers is null)
            {
                return InvokeWithoutBaseTypes(@event);
            }
            
            if (eventHandlersHolder.ExposeHandlers(typeof(TEvent)).TryGet(out var invokedTypeHandlers))
            {
                handlers.Add(invokedTypeHandlers);
            }
            
            var eventHandlersIterator = new EventHandlersIterator(handlers, handlersDebugger);
            cachedIterators.Add(typeof(TEvent), eventHandlersIterator);
            
            eventHandlersIterator.Iterate(@event);

            return true;
        }

        private Optional<List<Type>> GetParentTypes<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            List<Type> types = null;

            if (subscribedInterfacesCount != 0)
            {
                var interfaceTypes = GetType(@event).GetInterfaces();

                if (interfaceTypes.Length > 0)
                {
                    types ??= new();
                    types.AddRange(interfaceTypes);
                }
            }

            if (subscribedNonSealedClassesCount != 0)
            {
                var parentClassTypes = GetParentClassTypes(@event.GetType());

                if (parentClassTypes.Count > 0)
                {
                    types ??= new();
                    types.AddRange(parentClassTypes);
                }
            }

            return types;
        }

        private static Type GetType<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            return typeof(TEvent).IsSealed switch
            {
                true => typeof(TEvent),
                false => @event.GetType(),
            };
        }

        private static IReadOnlyList<Type> GetParentClassTypes(Type type)
        {
            if (type == typeof(object))
            {
                return Array.Empty<Type>();
            }
            
            List<Type> results = null;

            type = type.BaseType;

            while (type != typeof(object))
            {
                results ??= new();
                
                results.Add(type);

                type = type.BaseType;
            }

            return (results is null) switch
            {
                true => Array.Empty<Type>(),
                false => results,
            };
        }

        private bool InvokeWithoutBaseTypes<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            return (typeof(TEvent).IsSealed || (@event.GetType() == typeof(TEvent))) switch
            {
                true => InvokeConcrete(@event),
                false => InvokeVirtual(@event),
            };
        }

        private bool InvokeConcrete<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            var handlers = eventHandlersHolder.GetHandlers<TEvent>();
            return InvokeThese(@event, handlers);
        }

        private bool InvokeVirtual(IEvent @event)
        {
            var handlers = eventHandlersHolder.GetHandlers(@event.GetType());
            return InvokeThese(@event, handlers);
        }

        private bool InvokeThese<TEvent>(TEvent @event, IEnumerable<(Type HandlerType, Action<TEvent> Handler)> handlers)
            where TEvent : IEvent
        {
            if (!handlers.Any())
            {
                return false;
            }

            foreach (var (handlerType, handler) in handlers)
            {
                handlersDebugger.InvokeHandlerStarting(handlerType);
                
                handler(@event);
                
                handlersDebugger.InvokeHandlerEnded(handlerType);
            }

            return true;
        }
    }
}
