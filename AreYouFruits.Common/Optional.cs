using System;

namespace Starfish.Utils
{
    public static class Optional
    {
        public static Optional<T> None<T>()
        {
            return default;
        }

        public static Optional<T> Some<T>(T value)
        {
            return new Optional<T>(value);
        }

        public static Optional<T> Some<T>(T? nullableValue)
            where T : struct
        {
            if (nullableValue is { } value)
            {
                return new Optional<T>(value);
            }

            return default;
        }

        public static Optional<T> Reduce<T>(this Optional<T?> optionalNullable)
            where T : struct
        {
            if (optionalNullable.TryGet(out T? nullable))
            {
                return Some(nullable);
            }

            return default;
        }

        public static T GetOrDefault<T>(this Optional<T> optional)
        {
            return optional.TryGet(out T value) ? value : default!;
        }
    }

    public readonly struct Optional<T> : IEquatable<Optional<T>>, IEquatable<T>
    {
        private readonly T value;
        public bool IsInitialized { get; }

        public Optional(T value)
        {
            if (value is null)
            {
                this.value = default!;
                IsInitialized = false;

                return;
            }

            this.value = value;
            IsInitialized = true;
        }

        public bool TryGet(out T value)
        {
            value = this.value;
            return IsInitialized;
        }

        public override bool Equals(object obj)
        {
            return obj switch
            {
                Optional<T> optionalOther => Equals(optionalOther),
                T otherValue => Equals(otherValue),
                _ => false,
            };
        }

        public override int GetHashCode()
        {
            return IsInitialized ? HashCode.Combine(value, IsInitialized) : HashCode.Combine(IsInitialized);
        }
        
        public bool Equals(Optional<T> other)
        {
            if (other.TryGet(out T otherValue))
            {
                return Equals(otherValue);
            }

            return !IsInitialized;
        }

        public bool Equals(T other)
        {
            bool isInitialized = TryGet(out T value);
            bool otherIsNull = other is null;
            
            if (otherIsNull && !isInitialized)
            {
                return true;
            }

            if (otherIsNull != !isInitialized)
            {
                return false;
            }

            return value!.Equals(other);
        }

        public static implicit operator Optional<T>(T value)
        {
            return new Optional<T>(value);
        }
        
        public static bool operator ==(Optional<T> a, Optional<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator ==(Optional<T> a, T b)
        {
            return a.Equals(b);
        }

        public static bool operator ==(T a, Optional<T> b)
        {
            return b.Equals(a);
        }

        public static bool operator !=(Optional<T> a, Optional<T> b)
        {
            return !(a == b);
        }

        public static bool operator !=(Optional<T> a, T b)
        {
            return !(a == b);
        }

        public static bool operator !=(T a, Optional<T> b)
        {
            return !(a == b);
        }
    }
}