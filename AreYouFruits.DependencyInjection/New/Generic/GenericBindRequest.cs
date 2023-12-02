using System;

namespace AreYouFruits.DependencyInjection.New.Generic
{
    public sealed class GenericBindRequest<TRequested>
    {
        public Func<TRequested> RequestedTypeProvider { get; }

        public GenericBindRequest(Func<TRequested> requestedTypeProvider)
        {
            if (requestedTypeProvider is null)
            {
                throw new ArgumentNullException(nameof(requestedTypeProvider));
            }

            RequestedTypeProvider = requestedTypeProvider;
        }

        public BindRequest ToBindRequest()
        {
            return new BindRequest(typeof(TRequested), () => RequestedTypeProvider());
        }
    }
}
