using System;
using System.Diagnostics.CodeAnalysis;

namespace AreYouFruits.Nullability
{
    public partial struct Optional<T>
    {
        public readonly bool IsInitialized => isInitialized;

        public readonly bool TryGet([MaybeNullWhen(false)] out T value)
        {
            if (isInitialized)
            {
                value = this.value;
                return true;
            }
            
            value = default;
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

        public readonly void GetOrThrow(out T value) => value = GetOrThrow();
        
        public readonly void GetOrDefault([MaybeNull] out T value) => value = GetOrDefault();
    }
}
