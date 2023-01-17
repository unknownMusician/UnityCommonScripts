using System;

namespace AreYouFruits.DependencyInjection
{
    public interface IDiByTypeResolver
    {
        public object Resolve(Type type);
    }
}