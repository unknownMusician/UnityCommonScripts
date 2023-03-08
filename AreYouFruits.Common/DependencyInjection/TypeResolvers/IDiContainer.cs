using System;
using AreYouFruits.DependencyInjection.Binders;

namespace AreYouFruits.DependencyInjection
{
    public interface IDiContainer : IDiByTypeResolver
    {
        public IDiBinder Bind(Type type);
        public void Clear();
        public void Clear(Type type);
    }
}
