using System;
using AreYouFruits.Common.DependencyInjection.Binders;

namespace AreYouFruits.Common.DependencyInjection.TypeResolvers
{
    public interface IDiContainer : IDiByTypeResolver
    {
        public IDiBinder Bind(Type type);
        public void Clear();
        public void Clear(Type type);
    }
}
