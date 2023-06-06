using System;

namespace AreYouFruits.Common.DependencyInjection.TypeResolvers
{
    public interface IDiByTypeResolver
    {
        public bool TryResolve(Type type, out object result);
    }
}