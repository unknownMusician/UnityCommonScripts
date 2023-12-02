using System;
using AreYouFruits.Nullability;

namespace AreYouFruits.Events
{
    public readonly struct EventBusAccess
    {
        private readonly EventBus eventBus;
        private readonly Type callerType;

        public EventBusAccess(EventBus eventBus, Type callerType)
        {
            this.eventBus = eventBus;
            this.callerType = callerType;
        }

        public bool SubscribeHandler<TEvent>(Action<TEvent> eventHandler)
            where TEvent : IEvent
        {
            ThrowIfInvalid();

            return eventBus.SubscribeHandler(callerType, eventHandler);
        }

        public bool UnsubscribeHandler<TEvent>(Action<TEvent> eventHandler)
            where TEvent : IEvent
        {
            ThrowIfInvalid();

            return eventBus.UnsubscribeHandler(callerType, eventHandler);
        }

        public bool Invoke<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            ThrowIfInvalid();

            return eventBus.Invoke(@event);
        }

        public void SubscribeProvider<TRequest, TResponse>(Func<TRequest, TResponse> responseProvider)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            ThrowIfInvalid();

            eventBus.SubscribeProvider(responseProvider);
        }

        public bool UnsubscribeProvider<TRequest, TResponse>(Func<TRequest, TResponse> responseProvider)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            ThrowIfInvalid();

            return eventBus.UnsubscribeProvider(responseProvider);
        }

        public Optional<TResponse> Request<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            ThrowIfInvalid();

            return eventBus.Request<TRequest, TResponse>(request);
        }

        private void ThrowIfInvalid()
        {
            if (eventBus is null || callerType is null)
            {
                throw new InvalidOperationException($"{nameof(EventBusAccess)} is not initialized.");
            }
        }
    }
}
