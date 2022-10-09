using System;

namespace AreYouFruits.Common
{
    [Serializable]
    public struct SerializedNullable<T> : IEquatable<SerializedNullable<T>>, IEquatable<T>
        where T : IEquatable<T>
    {
        public static readonly SerializedNullable<T> Null = default;

        public T Value;
        public bool HasValue;

        public SerializedNullable(T value, bool hasValue)
        {
            Value = value;
            HasValue = hasValue;
        }

        public void Deconstruct(out T value, out bool hasValue)
        {
            (value, hasValue) = (Value, HasValue);
        }

        public bool IsNull(out T value)
        {
            if (HasValue)
            {
                value = Value;
                return false;
            }

            value = default!;
            return true;
        }

        public bool Equals(T other)
        {
            return !IsNull(out T value) && value.Equals(other);
        }
        public bool Equals(SerializedNullable<T> other)
        {
            if (HasValue != other.HasValue)
            {
                return false;
            }

            if (!HasValue)
            {
                return true;
            }
            
            return Value.Equals(other.Value);
        }

        public override bool Equals(object? obj)
        {
            return obj is SerializedNullable<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, HasValue);
        }

        public static bool operator ==(
            SerializedNullable<T> serializedNullable1, SerializedNullable<T> serializedNullable2
        )
        {
            return serializedNullable1.Equals(serializedNullable2);
        }

        public static bool operator !=(
            SerializedNullable<T> serializedNullable1, SerializedNullable<T> serializedNullable2
        )
        {
            return !serializedNullable1.Equals(serializedNullable2);
        }

        public static bool operator ==(
            SerializedNullable<T> serializedNullable, T nullable
        )
        {
            return serializedNullable.Equals(nullable);
        }

        public static bool operator !=(
            SerializedNullable<T> serializedNullable, T nullable
        )
        {
            return !serializedNullable.Equals(nullable);
        }
    }
}

