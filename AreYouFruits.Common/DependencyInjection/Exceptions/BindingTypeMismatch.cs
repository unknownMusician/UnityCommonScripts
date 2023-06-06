using System;

namespace AreYouFruits.Common.DependencyInjection.Exceptions
{
    public sealed class BindingTypeMismatch : ArgumentException
    {
        public BindingTypeMismatch() : base("Source type is not assignable from Destination type.") { }

        public BindingTypeMismatch(Type sourceType, Type destinationType) : base(
            $"Source type {sourceType} is not assignable from Destination type {destinationType}.") { }

        public BindingTypeMismatch(Type sourceType, object destinationObject) : base(
            $"Source type {sourceType} is not assignable from Destination type {destinationObject?.GetType().FullName ?? "Null"}.") { }
    }
}