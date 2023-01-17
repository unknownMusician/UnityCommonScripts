using System;

namespace AreYouFruits.DependencyInjection.Exceptions
{
    public sealed class BindingCollisionException : InvalidOperationException
    {
        public BindingCollisionException() : base("Type is already bound.") { }

        public BindingCollisionException(Type sourceType) :
            base($"Type {sourceType} is already bound.") { }
    }
}