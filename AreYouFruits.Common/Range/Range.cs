using System;
using System.Collections.Generic;

namespace AreYouFruits.Common
{
    [Serializable]
    public struct Range<T> : IEquatable<Range<T>>
    {
        public T Min;
        public T Max;
        public bool IsBound;

        public Range(in T min, in T max)
        {
            Min = min;
            Max = max;
            IsBound = true;
        }

        public readonly void Deconstruct(out T min, out T max)
        {
            (min, max) = (Min, Max);
        }

        public readonly void Deconstruct(out T min, out T max, out bool isBounded)
        {
            (min, max, isBounded) = (Min, Max, IsBound);
        }

        public readonly bool Equals(Range<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Min, other.Min)
             && EqualityComparer<T>.Default.Equals(Max, other.Max) && (IsBound == other.IsBound);
        }

        public readonly override bool Equals(object? obj) => obj is Range<T> other && Equals(other);

        public readonly override int GetHashCode()
        {
            return HashCode.Combine(Min, Max, IsBound);
        }

        public static implicit operator Range<T>(in (T min, T max) tuple)
        {
            return new Range<T>(tuple.min, tuple.max);
        }
    }
}