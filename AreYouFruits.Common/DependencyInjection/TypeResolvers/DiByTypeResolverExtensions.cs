using System;

namespace AreYouFruits.DependencyInjection
{
    public static class DiByTypeResolverExtensions
    {
        public static object Resolve(this IDiByTypeResolver resolver, Type type)
        {
            if (!resolver.TryResolve(type, out object result))
            {
                throw new InvalidOperationException($"No object of type {type} bound.");
            }

            return result;
        }
    }
}