using System;
using AreYouFruits.DependencyInjection.Binders;

namespace AreYouFruits.DependencyInjection.BinderProviders
{
    public interface IBindingsHolder : IBindingsProvider
    {
        public void Add(IDiBinding binding);
        public void TryRemove(Type type);
    }
}