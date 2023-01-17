using System;
using AreYouFruits.DependencyInjection.Binders;

namespace AreYouFruits.DependencyInjection.ContextInitialization
{
    public sealed class ContextInitializerDiContainerDecorator : IDiContainer
    {
        private readonly IDiContainer _container;

        private bool _isInitialized;

        public ContextInitializerDiContainerDecorator(IDiContainer container)
        {
            _container = container;
        }

        public object Resolve(Type type)
        {
            ContextInitializer.TryInitialize();

            return _container.Resolve(type);
        }

        public IDiBinder Bind(Type type)
        {
            return _container.Bind(type);
        }

        public void Clear()
        {
            _container.Clear();
        }

        public void ClearBinding(Type type)
        {
            _container.ClearBinding(type);
        }
    }
}