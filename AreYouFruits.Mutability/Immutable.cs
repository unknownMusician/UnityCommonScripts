using System;
using System.Collections.Generic;

namespace AreYouFruits.Mutability
{
    public readonly struct Immutable<T> : IEquatable<Immutable<T>>
        where T : struct
    {
        public readonly T Value;

        public Immutable(in T value)
        {
            Value = value;
        }

        public bool Equals(Immutable<T> other) => EqualityComparer<T>.Default.Equals(Value, other.Value);

        public override bool Equals(object obj) => obj is Immutable<T> other && Equals(other);

        public override int GetHashCode() => EqualityComparer<T>.Default.GetHashCode(Value);

        public override string ToString() => $"{nameof(Value)}: {Value.ToString()}";

        public static bool operator ==(Immutable<T> a, Immutable<T> b) => a.Equals(b);
        public static bool operator !=(Immutable<T> a, Immutable<T> b) => !(a == b);

        public static implicit operator Immutable<T>(in T value)
        {
            return new Immutable<T>(in value);
        }
    }
}