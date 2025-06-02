using System;
using System.Collections.Generic;
using AreYouFruits.Nullability;

namespace AreYouFruits.Events
{
    public sealed class EventHandlersIterator
    {
        private readonly Optional<IHandlersDebugger> handlersDebugger;
        private readonly List<SortedDictionary<long, Dictionary<Type, Action<IEvent>>>> handlers;
        private readonly SubstitutingTakenWithLastList<SortedDictionary<long, Dictionary<Type, Action<IEvent>>>.Enumerator> enumerators;

        public EventHandlersIterator(
            List<SortedDictionary<long, Dictionary<Type, Action<IEvent>>>> handlers,
            Optional<IHandlersDebugger> handlersDebugger
        )
        {
            this.handlers = handlers;
            this.handlersDebugger = handlersDebugger;
            enumerators = new(handlers.Count);
        }

        public void Iterate(IEvent @event)
        {
            for (var i = 0; i < handlers.Count; i++)
            {
                var typeHandlers = handlers[i];
                var enumerator = typeHandlers.GetEnumerator();
                
                if (enumerator.MoveNext())
                {
                    enumerators.Add(enumerator);
                }
                else
                {
                    enumerator.Dispose();
                }
            }

            while (enumerators.Count != 0)
            {
                var leastIndex = 0;
                var leastOrder = enumerators[0].Current.Key;

                for (var i = 0; i < enumerators.Count; i++)
                {
                    var order = enumerators[i].Current.Key;

                    if (order < leastOrder)
                    {
                        leastIndex = i;
                        leastOrder = order;
                    }
                }

                var enumerator = enumerators[leastIndex];

                foreach (var handler in enumerator.Current.Value)
                {
                    handlersDebugger.InvokeHandlerStarting(handler.Key);
                    
                    handler.Value(@event);
                    
                    handlersDebugger.InvokeHandlerEnded(handler.Key);
                }

                if (enumerator.MoveNext())
                {
                    enumerators[leastIndex] = enumerator;
                }
                else
                {
                    enumerator.Dispose();
                    enumerators.RemoveAt(leastIndex);
                }
            }
        }
    }
}