using System;
using System.Diagnostics.CodeAnalysis;

namespace AreYouFruits.Nullability
{
    public partial struct Optional<T>
    {
        public bool IsInitialized => isInitialized;

        public bool TryGet([MaybeNullWhen(false)] out T value)
        {
            if (isInitialized)
            {
                value = this.value;
                return true;
            }
            
            value = default;
            return false;
        }

        public T GetOr(T defaultValue)
        {
            return isInitialized switch
            {
                true => value,
                false => defaultValue,
            };
        }

        [return: MaybeNull]
        public T GetOrDefault() => GetOr(default);

        public T GetOrThrow()
        {
            return isInitialized switch
            {
                true => value,
                false => throw new NullReferenceException(),
            };
        }

        public void GetOrThrow(out T value) => value = GetOrThrow();
        
        public void GetOrDefault([MaybeNull] out T value) => value = GetOrDefault();
    }
}
