using System;

namespace AreYouFruits.DependencyInjection.Exceptions
{
    public sealed class UnfinishedBindingException : InvalidOperationException
    {
        public UnfinishedBindingException() : base("Type has not finished binding.") { }

        public UnfinishedBindingException(Type sourceType) :
            base($"Type {sourceType} has not finished binding.") { }
    }
}
