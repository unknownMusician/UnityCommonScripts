using System;

namespace AreYouFruits.DependencyInjection.TypeResolvers
{
    public interface IDiByTypeResolver
    {
        public bool TryResolve(Type type, out object result);
    }
}