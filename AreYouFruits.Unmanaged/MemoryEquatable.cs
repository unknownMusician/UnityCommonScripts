using System;

namespace AreYouFruits.Unmanaged
{
    public readonly struct MemoryEquatable<T> : IEquatable<MemoryEquatable<T>>, IEquatable<T>
        where T : unmanaged
    {
        public T Value { get; }

        public MemoryEquatable(in T value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj switch
            {
                T other => UnmanagedEqualityComparer.Equals(Value, other),
                MemoryEquatable<T> otherUnmanaged => Equals(otherUnmanaged),
                _ => false,
            };
        }

        public override int GetHashCode()
        {
            return UnmanagedEqualityComparer.GetHashCode(Value);
        }

        public bool Equals(MemoryEquatable<T> other)
        {
            return UnmanagedEqualityComparer.Equals(this, other);
        }

        public bool Equals(T other)
        {
            return UnmanagedEqualityComparer.Equals(Value, other);
        }

        public static implicit operator MemoryEquatable<T>(T value)
        {
            return new MemoryEquatable<T>(value);
        }
    }
}