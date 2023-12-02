using System;

namespace AreYouFruits.DependencyInjection.New
{
    public sealed class BindRequest
    {
        public Type RequestedType { get; }
        public Func<IReadOnlyResolveContext, bool> Filter { get; }
        public Func<object> RequestedTypeProvider { get; }

        public BindRequest(
            Type requestedType,
            Func<IReadOnlyResolveContext, bool> filter,
            Func<object> requestedTypeProvider
        )
        {
            if (requestedType is null)
            {
                throw new ArgumentNullException(nameof(requestedType));
            }

            if (filter is null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            if (requestedTypeProvider is null)
            {
                throw new ArgumentNullException(nameof(requestedTypeProvider));
            }

            RequestedType = requestedType;
            Filter = filter;
            RequestedTypeProvider = requestedTypeProvider;
        }
    }
}
