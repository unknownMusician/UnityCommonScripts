using System;
using AreYouFruits.Common.DependencyInjection.Binders;

namespace AreYouFruits.Common.DependencyInjection.BinderProviders
{
    public interface IBindingsHolder : IBindingsProvider
    {
        public void Add(IDiBinding binding);
        public void TryRemove(Type type);
    }
}