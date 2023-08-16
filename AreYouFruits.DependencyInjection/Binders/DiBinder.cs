using System;
using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection.Binders
{
    public sealed class DiBinder : IDiBinder, IDiBinding
    {
        public Type SourceType { get; }
        public IResolver<object> Resolver { get; private set; }

        public DiBinder(Type source)
        {
            SourceType = source;
        }

        public void To(IResolver<object> resolver)
        {
            if (resolver is null)
            {
                throw new ArgumentNullException(nameof(resolver), "Cannot bind to null IResolver.");
            }

            if (Resolver is not null)
            {
                throw new InvalidOperationException("This IDiBinder is already bound.");
            }

            Resolver = resolver;
        }
    }
}