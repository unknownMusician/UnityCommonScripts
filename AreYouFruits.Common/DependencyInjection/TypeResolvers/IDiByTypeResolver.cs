using System;

namespace AreYouFruits.DependencyInjection
{
    public interface IDiByTypeResolver
    {
        public bool TryResolve(Type type, out object result);
    }
}