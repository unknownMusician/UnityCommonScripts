using System;
using AreYouFruits.DependencyInjection.TypeResolvers;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class ByTypeResolverOutExtensions
    {
        public static void Resolve(this IDiByTypeResolver resolver, Type type, out object value)
        {
            value = resolver.Resolve(type);
        }
    }
}