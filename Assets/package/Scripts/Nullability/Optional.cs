using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace AreYouFruits.Nullability
{
    public static class Optional
    {
        public static NullOptional None() => new();
        
        public static Optional<T> Reduce<T>(this Optional<T?> optionalNullable)
            where T : struct
        {
            if (optionalNullable.TryGet(out T? nullable))
            {
                return Some(nullable);
            }

            return default;
        }
        
        public static Optional<T> None<T>() => new();
        
        public static Optional<T> Some<T>(T value) => new(value);
        
        public static Optional<T> Some<T>(T? nullableValue)
            where T : struct
        {
            if (nullableValue is { } value)
            {
                return new Optional<T>(value);
            }

            return default;
        }
    }
    
    [Serializable]
    public struct Optional<T> : IEquatable<Optional<T>>, IEquatable<T>
    {
        [SerializeField] private T value;
        [SerializeField] private bool isInitialized;
        
        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public readonly bool IsInitialized => isInitialized;
        
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
        
        public readonly override string ToString()
        {
            string valueString = (isInitialized, value) switch
            {
                (true, not null) => value.ToString(),
                _ => "Null",
            };

            return $"Optional<{typeof(T).Name}> {{ {valueString} }}";
        }
        
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
            if (other.TryGet(out var otherValue))
            {
                return Equals(otherValue);
            }

            return !isInitialized;
        }

        public readonly bool Equals(T other)
        {
            var otherIsNull = other is null;
            
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
        
        public static implicit operator Optional<T>(T value) => new(value);
        public static implicit operator Optional<T>(NullOptional _) => new();
        
        public readonly Optional<TOther> As<TOther>()
        {
            if (!isInitialized || value is not TOther other)
            {
                return default;
            }

            return other;
        }
        
        public readonly bool TryGet([MaybeNullWhen(false)] out T v)
        {
            if (isInitialized)
            {
                v = value;
                return true;
            }
            
            v = default;
            return false;
        }

        public readonly T GetOr(T defaultValue)
        {
            return isInitialized switch
            {
                true => value,
                false => defaultValue,
            };
        }

        public readonly Optional<T> GetOr(Optional<T> defaultValue)
        {
            return isInitialized switch
            {
                true => value,
                false => defaultValue,
            };
        }

        public readonly T GetOr(Func<T> defaultValueProvider)
        {
            return isInitialized switch
            {
                true => value,
                false => defaultValueProvider(),
            };
        }

        public readonly Optional<T> GetOr(Func<Optional<T>> defaultValueProvider)
        {
            return isInitialized switch
            {
                true => value,
                false => defaultValueProvider(),
            };
        }

        [return: MaybeNull]
        public readonly T GetOrDefault() => GetOr(default(T));

        public readonly T GetOrThrow()
        {
            return isInitialized switch
            {
                true => value,
                false => throw new NullReferenceException(),
            };
        }

        public readonly void GetOrThrow(out T v) => v = GetOrThrow();
        
        public readonly void GetOrDefault([MaybeNull] out T v) => v = GetOrDefault();
        
        public readonly void Switch(Action<T> valueHandler)
        {
            if (isInitialized)
            {
                valueHandler(value);
            }
        }
        public readonly void Switch(Action emptyHandler)
        {
            if (!isInitialized)
            {
                emptyHandler();
            }
        }

        public readonly void Switch(Action emptyHandler, Action<T> valueHandler) => Switch(valueHandler, emptyHandler);
        public readonly void Switch(Action<T> valueHandler, Action emptyHandler)
        {
            if (isInitialized)
            {
                valueHandler(value);
            }
            else
            {
                emptyHandler();
            }
        }

        public readonly TResult Match<TResult>(Func<TResult> emptyHandler, Func<T, TResult> valueHandler)
        {
            return Match(valueHandler, emptyHandler);
        }
        
        public readonly TResult Match<TResult>(Func<T, TResult> valueHandler, Func<TResult> emptyHandler)
        {
            return isInitialized switch
            {
                true => valueHandler(value),
                false => emptyHandler(),
            };
        }
        
        public readonly Optional<TResult> Match<TResult>(Func<T, TResult> valueHandler)
        {
            return isInitialized switch
            {
                true => valueHandler(value),
                false => Optional.None(),
            };
        }
        
        public T Set(Func<T> emptyProvider, Func<T, T> valueProvider) => Set(valueProvider, emptyProvider);
        public T Set(Func<T, T> valueProvider, Func<T> emptyProvider)
        {
            var newValue = isInitialized switch
            {
                true => valueProvider(this.value),
                false => emptyProvider(),
            };

            this = new Optional<T>(newValue);

            return newValue;
        }

        public Optional<T> Set(Func<Optional<T>> emptyProvider, Func<T, Optional<T>> valueProvider)
        {
            return Set(valueProvider, emptyProvider);
        }
        public Optional<T> Set(Func<T, Optional<T>> valueProvider, Func<Optional<T>> emptyProvider)
        {
            return this = isInitialized switch
            {
                true => valueProvider(value),
                false => emptyProvider(),
            };
        }
        
        public T SetIfNull(T newValue)
        {
            if (!isInitialized)
            {
                this = new Optional<T>(newValue);
            }

            return value;
        }

        public Optional<T> SetIfNull(Optional<T> newValue)
        {
            if (!isInitialized)
            {
                this = newValue;
            }

            return this;
        }

        public Optional<T> SetIfNull(Func<Optional<T>> valueProvider)
        {
            if (!isInitialized)
            {
                this = valueProvider();
            }

            return this;
        }
        
        public T SetIfNull(Func<T> valueProvider)
        {
            if (!isInitialized)
            {
                this = new Optional<T>(valueProvider());
            }

            return value;
        }
        
        public T SetIfInitialized(T newValue)
        {
            if (isInitialized)
            {
                this = new Optional<T>(newValue);
            }

            return value;
        }

        public Optional<T> SetIfInitialized(Optional<T> v)
        {
            if (isInitialized)
            {
                this = v;
            }

            return this;
        }

        public Optional<T> SetIfInitialized(Func<Optional<T>> valueProvider)
        {
            if (isInitialized)
            {
                this = valueProvider();
            }

            return this;
        }
        
        public T SetIfInitialized(Func<T> valueProvider)
        {
            if (isInitialized)
            {
                this = new Optional<T>(valueProvider());
            }

            return value;
        }

        public T SetOrThrow(T newValue)
        {
            if (isInitialized)
            {
                throw new InvalidOperationException("The Option is already initialized.");
            }
            
            this = new Optional<T>(newValue);

            return newValue;
        }

        public Optional<T> SetOrThrow(Optional<T> newValue)
        {
            if (isInitialized)
            {
                throw new InvalidOperationException("The Option is already initialized.");
            }
            
            this = newValue;

            return newValue;
        }
    }
}
