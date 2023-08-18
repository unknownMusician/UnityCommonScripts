using System;
using System.Collections.Generic;

namespace AreYouFruits.Nullability
{
    [Serializable]
    public partial struct Optional<T> : IEquatable<Optional<T>>, IEquatable<T>
    {
        public readonly override int GetHashCode()
        {
            return isInitialized switch
            {
                true => HashCode.Combine(value, isInitialized),
                false => HashCode.Combine(isInitialized),
            };
        }
        
        public readonly override bool Equals(object obj)
        {
            return obj switch
            {
                Optional<T> optionalOther => Equals(optionalOther),
                T otherValue => Equals(otherValue),
                _ => false,
            };
        }
        
        public readonly bool Equals(Optional<T> other)
        {
            if (other.TryGet(out T otherValue))
            {
                return Equals(otherValue);
            }

            return !isInitialized;
        }

        public readonly bool Equals(T other)
        {
            bool otherIsNull = other is null;
            
            if (otherIsNull && !isInitialized)
            {
                return true;
            }

            if (otherIsNull != !isInitialized)
            {
                return false;
            }

            return EqualityComparer<T>.Default.Equals(value, other);
        }

        public static bool operator ==(Optional<T> a, Optional<T> b) => a.Equals(b);
        public static bool operator ==(Optional<T> a, T b) => a.Equals(b);
        public static bool operator ==(T a, Optional<T> b) => b.Equals(a);

        public static bool operator !=(Optional<T> a, Optional<T> b) => !(a == b);
        public static bool operator !=(Optional<T> a, T b) => !(a == b);
        public static bool operator !=(T a, Optional<T> b) => !(a == b);
    }
}