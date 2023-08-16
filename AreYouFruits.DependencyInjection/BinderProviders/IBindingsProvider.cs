using System;
using AreYouFruits.DependencyInjection.Binders;

namespace AreYouFruits.DependencyInjection.BinderProviders
{
    public interface IBindingsProvider
    {
        public bool TryGet(Type type, out IDiBinding binding);
    }
}