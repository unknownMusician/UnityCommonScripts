using System;

namespace AreYouFruits.Common
{
    [Serializable]
    public struct UnmanagedRange<T> : IEquatable<UnmanagedRange<T>>
        where T : unmanaged
    {
        public T Min;
        public T Max;
        public bool IsBounded;

        public UnmanagedRange(in T min, in T max)
        {
            Min = min;
            Max = max;
            IsBounded = true;
        }

        public readonly void Deconstruct(out T min, out T max)
        {
            (min, max) = (Min, Max);
        }

        public readonly void Deconstruct(out T min, out T max, out bool isBounded)
        {
            (min, max, isBounded) = (Min, Max, IsBounded);
        }

        public readonly bool Equals(UnmanagedRange<T> other)
        {
            return UnmanagedEqualityComparer.Equals(this, other);
        }

        public readonly override bool Equals(object? obj)
        {
            return obj is UnmanagedRange<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return UnmanagedEqualityComparer.GetHashCode(this);
        }

        public static implicit operator UnmanagedRange<T>(in (T min, T max) tuple)
        {
            return new UnmanagedRange<T>(tuple.min, tuple.max);
        }
    }
}