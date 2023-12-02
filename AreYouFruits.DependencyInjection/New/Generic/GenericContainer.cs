using System;

namespace AreYouFruits.DependencyInjection.New.Generic
{
    public sealed class GenericContainer
    {
        private readonly Container container = new();
        
        public void Bind<T>(GenericBindRequest<T> bindRequest)
        {
            if (bindRequest is null)
            {
                throw new ArgumentNullException(nameof(bindRequest));
            }
            
            container.Bind(bindRequest.ToBindRequest());
        }

        public T Resolve<T>(GenericResolveRequest<T> resolveRequest)
        {
            if (resolveRequest is null)
            {
                throw new ArgumentNullException(nameof(resolveRequest));
            }

            return (T)container.Resolve(resolveRequest.ToResolveRequest());
        }
    }
}
