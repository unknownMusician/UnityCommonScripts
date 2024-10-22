using System;
using System.Collections.Generic;

namespace AreYouFruits.Ranges
{
    public static class Range
    {
        public static Range<T> From<T>(T min, T max)
        {
            return new Range<T>(min, max);
        }
    }
    
    [Serializable]
    public struct Range<T> : IEquatable<Range<T>>
    {
        public T Min;
        public T Max;

        public Range(in T min, in T max)
        {
            Min = min;
            Max = max;
        }

        public readonly void Deconstruct(out T min, out T max)
        {
            (min, max) = (Min, Max);
        }

        public readonly bool Equals(Range<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Min, other.Min)
             && EqualityComparer<T>.Default.Equals(Max, other.Max);
        }

        public readonly override bool Equals(object obj)
        {
            return obj is Range<T> other && Equals(other);
        }

        public readonly override int GetHashCode()
        {
            return HashCode.Combine(Min, Max);
        }

        public static implicit operator Range<T>(in (T min, T max) tuple)
        {
            return new Range<T>(tuple.min, tuple.max);
        }
    }
}