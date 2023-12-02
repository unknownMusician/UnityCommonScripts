using System;
using System.Linq;
using AreYouFruits.Nullability;

namespace AreYouFruits.Events
{
    public sealed class EventBus
        // todo: Make ordering optional for user.
        // todo: Add polymorphic handling.
    {
        private readonly ResponseProvidersHolder responseProvidersHolder = new();
        private readonly EventHandlersHolder eventHandlersHolder;

        public EventBus(HandlersOrderer handlersOrderer)
        {
            eventHandlersHolder = new(handlersOrderer);
        }

        public EventBusAccess Authorise(Type callerType)
        {
            return new EventBusAccess(this, callerType);
        }

        public EventBusAccess Authorise(object caller)
        {
            return Authorise(caller.GetType());
        }

        internal bool SubscribeHandler<TEvent>(Type callerType, Action<TEvent> eventHandler)
            where TEvent : IEvent
        {
            return eventHandlersHolder.Subscribe(callerType, eventHandler);
        }

        internal bool UnsubscribeHandler<TEvent>(Type callerType, Action<TEvent> eventHandler)
            where TEvent : IEvent
        {
            return eventHandlersHolder.Unsubscribe(callerType, eventHandler);
        }

        internal bool Invoke<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            var handlers = eventHandlersHolder.GetHandlers<TEvent>();

            if (!handlers.Any())
            {
                return false;
            }

            foreach (Action<TEvent> handler in handlers)
            {
                handler(@event);
            }

            return true;
        }

        internal void SubscribeProvider<TRequest, TResponse>(Func<TRequest, TResponse> responseProvider)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            responseProvidersHolder.Subscribe(responseProvider);
        }

        internal bool UnsubscribeProvider<TRequest, TResponse>(Func<TRequest, TResponse> responseProvider)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            return responseProvidersHolder.Unsubscribe(responseProvider);
        }

        internal Optional<TResponse> Request<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            if (!responseProvidersHolder.GetProvider<TRequest, TResponse>().TryGet(out var responseProvider))
            {
                return Optional.None();
            }

            var requestHandlers = eventHandlersHolder.GetHandlers<TRequest>();
            var responseHandlers = eventHandlersHolder.GetHandlers<TResponse>();

            foreach (Action<TRequest> requestHandler in requestHandlers)
            {
                requestHandler(request);
            }

            var response = responseProvider(request);

            foreach (Action<TResponse> responseHandler in responseHandlers)
            {
                responseHandler(response);
            }

            return response;
        }
    }
}
