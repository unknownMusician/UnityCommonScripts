using System;
using AreYouFruits.DependencyInjection.Binders;

namespace AreYouFruits.DependencyInjection.ContextInitialization
{
    public sealed class ContextInitializerKeyedDiContainerDecorator : IKeyedDiContainer
    {
        private readonly IKeyedDiContainer container;
        private readonly Action<IKeyedDiContainer>? initializer;

        public ContextInitializerKeyedDiContainerDecorator(
            IKeyedDiContainer container, Action<IKeyedDiContainer>? initializer = null
        )
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

        public IDiContainer For(object key)
        {
            Action<IDiContainer>? initializer = this.initializer is null ?
                (Action<IDiContainer>?)null :
                _ => this.initializer(container);

            return new ContextInitializerDiContainerDecorator(container.For(key), initializer);
        }
    }
}