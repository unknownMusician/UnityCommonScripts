using System.Diagnostics.CodeAnalysis;

namespace AreYouFruits.Nullability
{
    public static partial class Optional
    {
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

    public partial struct Optional<T>
    {
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
        
        public static implicit operator Optional<T>(T value) => new(value);
    }
}
