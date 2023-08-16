using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AreYouFruits.Nullability
{
    public static class Optional
    {
        public static Optional<T> Some<T>(T value) => new(value);
        public static Optional<T> None<T>() => new();
        public static NullOptional None() => new();

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
    }

    [Serializable]
    public struct Optional<T> : IEquatable<Optional<T>>, IEquatable<T>
    {
        private T value;
        private bool isInitialized;
        
        public bool IsInitialized => isInitialized;

        public Optional([MaybeNull] T value)
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
        
        public bool TryGet([MaybeNullWhen(false)] out T value)
        {
            if (IsInitialized)
            {
                value = this.value;

                return true;
            }
            
            value = default;
            
            return false;
        }

        public T GetOr(T defaultValue)
        {
            return IsInitialized switch
            {
                true => value,
                false => defaultValue,
            };
        }

        [return: MaybeNull]
        public T GetOrDefault() => GetOr(default);

        public T GetOrThrow()
        {
            return IsInitialized switch
            {
                true => value,
                false => throw new NullReferenceException(),
            };
        }

        public void GetOrThrow(out T value) => value = GetOrThrow();
        
        public void GetOrDefault([MaybeNull] out T value) => value = GetOrDefault();

        public void Switch(Action<T> valueHandler, Action emptyHandler)
        {
            switch (isInitialized)
            {
                case true:
                {
                    valueHandler(value);
                    break;
                }
                case false:
                {
                    emptyHandler();
                    break;
                }
            }
        }

        public TResult Match<TResult>(Func<T, TResult> valueHandler, Func<TResult> emptyHandler)
        {
            return isInitialized switch
            {
                true => valueHandler(value),
                false => emptyHandler(),
            };
        }

        public Optional<TOther> As<TOther>()
        {
            if (!isInitialized || value is not TOther other)
            {
                return default;
            }

            return other;
        }

        public override string ToString()
        {
            string stringValue = (isInitialized, value) switch
            {
                (true, not null) => value.ToString(),
                _ => "Null",
            };

            return $"Optional {{ {stringValue} }}";
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
            return IsInitialized switch
            {
                true => HashCode.Combine(value, IsInitialized),
                false => HashCode.Combine(IsInitialized),
            };
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

            return EqualityComparer<T>.Default.Equals(value, other);
        }
        
        public static implicit operator Optional<T>(NullOptional nullOptional) => new();

        public static implicit operator Optional<T>(T value) => new(value);

        public static bool operator ==(Optional<T> a, Optional<T> b) => a.Equals(b);
        public static bool operator ==(Optional<T> a, T b) => a.Equals(b);
        public static bool operator ==(T a, Optional<T> b) => b.Equals(a);

        public static bool operator !=(Optional<T> a, Optional<T> b) => !(a == b);
        public static bool operator !=(Optional<T> a, T b) => !(a == b);
        public static bool operator !=(T a, Optional<T> b) => !(a == b);
    }
}