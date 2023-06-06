using System;
using AreYouFruits.Common.DependencyInjection.Binders;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.ContextInitialization
{
    public sealed class ContextInitializerDiContainerDecorator : IDiContainer
    {
        private readonly IDiContainer container;
        private readonly Action<IDiContainer> initializer;

        public ContextInitializerDiContainerDecorator(IDiContainer container, Action<IDiContainer> initializer = null)
        {
            if (container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            this.container = container;
            this.initializer = initializer;
        }

        public bool TryResolve(Type type, out object result)
        {
            initializer?.Invoke(container);

            return container.TryResolve(type, out result);
        }

        public IDiBinder Bind(Type type)
        {
            return container.Bind(type);
        }

        public void Clear()
        {
            container.Clear();
        }

        public void Clear(Type type)
        {
            container.Clear(type);
        }
    }
}