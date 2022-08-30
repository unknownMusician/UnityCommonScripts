using System;
using System.Collections.Generic;

namespace AreYouFruits.Common.Mutability
{
    public readonly struct Immutable<T> : IEquatable<Immutable<T>>
        where T : struct
    {
        public readonly T Value;

        public Immutable(in T value)
        {
            Value = value;
        }

        public bool Equals(Immutable<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            return obj is Immutable<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return $"{nameof(Value)}: {Value}";
        }

        public static bool operator ==(Immutable<T> a, Immutable<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Immutable<T> a, Immutable<T> b)
        {
            return !a.Equals(b);
        }
        
        public static implicit operator Immutable<T>(in T value)
        {
            return new Immutable<T>(in value);
        }
    }
}