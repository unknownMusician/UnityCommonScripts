using System;
using AreYouFruits.DependencyInjection.Binders;

namespace AreYouFruits.DependencyInjection.BinderProviders
{
    public interface IBindingsProvider
    {
        public IDiBinding Get(Type type);
    }
}