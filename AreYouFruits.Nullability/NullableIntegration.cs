namespace AreYouFruits.Nullability
{
    public static partial class Optional
    {
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
}
