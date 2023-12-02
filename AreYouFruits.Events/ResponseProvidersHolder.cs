using System;
using System.Collections.Generic;
using System.Linq;
using AreYouFruits.Nullability;

namespace AreYouFruits.Events
{
    public sealed class ResponseProvidersHolder
    {
        private readonly TypedDictionary handlers = new();

        public void Subscribe<TRequest, TResponse>(Func<TRequest, TResponse> responseProvider)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            if (!handlers.Get<List<Func<TRequest, TResponse>>>().TryGet(out var typedResponseProviders))
            {
                typedResponseProviders = new();
                handlers.Add(typedResponseProviders);
            }

            typedResponseProviders.Add(responseProvider);
        }

        public bool Unsubscribe<TRequest, TResponse>(Func<TRequest, TResponse> responseProvider)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            if (!handlers.Get<List<Func<TRequest, TResponse>>>().TryGet(out var typedResponseProviders))
            {
                return false;
            }

            typedResponseProviders.Remove(responseProvider);

            if (!typedResponseProviders.Any())
            {
                handlers.Remove<List<Func<TRequest, TResponse>>>();
            }

            return true;
        }

        public Optional<Func<TRequest, TResponse>> GetProvider<TRequest, TResponse>()
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            if (!handlers.Get<List<Func<TRequest, TResponse>>>().TryGet(out var typedResponseProviders))
            {
                return Optional.None();
            }

            if (typedResponseProviders.Count != 1)
            {
                return Optional.None();
            }

            return typedResponseProviders.First();
        }
    }
}
