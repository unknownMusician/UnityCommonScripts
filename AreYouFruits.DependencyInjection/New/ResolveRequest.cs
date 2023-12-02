using System;

namespace AreYouFruits.DependencyInjection.New
{
    public sealed class ResolveRequest
    {
        public Type RequestedType { get; }

        public ResolveRequest(Type requestedType)
        {
            if (requestedType is null)
            {
                throw new ArgumentNullException(nameof(requestedType));
            }

            RequestedType = requestedType;
        }
    }
}
