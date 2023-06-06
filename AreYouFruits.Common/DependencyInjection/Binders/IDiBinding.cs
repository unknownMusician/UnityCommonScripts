using System;
using AreYouFruits.Common.DependencyInjection.Resolvers;

namespace AreYouFruits.Common.DependencyInjection.Binders
{
    public interface IDiBinding
    {
        public Type SourceType { get; }
        public IResolver<object> Resolver { get; }
    }
}