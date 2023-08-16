using System;
using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection.Binders
{
    public interface IDiBinding
    {
        public Type SourceType { get; }
        public IResolver<object> Resolver { get; }
    }
}