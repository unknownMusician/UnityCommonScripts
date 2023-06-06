using System;

namespace AreYouFruits.Utils
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
            return optional.GetOr(default);
        }

        public static T GetOr<T>(this Optional<T> optional, T defaultValue)
        {
            if (!optional.TryGet(out T value))
            {
                return defaultValue;
            }

            return value;
        }

        public static T GetOrThrow<T>(this Optional<T> optional)
        {
            if (!optional.TryGet(out T value))
            {
                throw new NullReferenceException();
            }

            return value;
        }
    }

    public struct Optional<T> : IEquatable<Optional<T>>, IEquatable<T>
    {
        private T value;
        private bool isInitialized;
        public bool IsInitialized => isInitialized;

        public Optional(T value)
        {
            if (value is null)
            {
                this.value = default!;
                isInitialized = false;

                return;
            }

            this.value = value;
            isInitialized = true;
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