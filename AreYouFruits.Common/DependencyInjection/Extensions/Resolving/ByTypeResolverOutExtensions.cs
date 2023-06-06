using System;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Resolving
{
    public static class ByTypeResolverOutExtensions
    {
        public static void Resolve(this IDiByTypeResolver resolver, Type type, out object value)
        {
            value = resolver.Resolve(type);
        }
    }
}