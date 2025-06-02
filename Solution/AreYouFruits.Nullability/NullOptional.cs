namespace AreYouFruits.Nullability
{
    public readonly struct NullOptional { }

    public static partial class Optional
    {
        public static NullOptional None() => new();
    }

    public partial struct Optional<T>
    {
        public static implicit operator Optional<T>(NullOptional nullOptional) => new();
    }
}