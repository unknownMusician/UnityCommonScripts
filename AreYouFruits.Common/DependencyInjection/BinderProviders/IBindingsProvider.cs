using System;
using AreYouFruits.Common.DependencyInjection.Binders;

namespace AreYouFruits.Common.DependencyInjection.BinderProviders
{
    public interface IBindingsProvider
    {
        public bool TryGet(Type type, out IDiBinding binding);
    }
}