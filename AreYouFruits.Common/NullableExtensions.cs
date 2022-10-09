namespace AreYouFruits.Common
{
    public static class NullableExtensions
    {
        public static bool IsNull<T>(this T? nullable, out T value)
            where T : struct
        {
            if (nullable is null)
            {
                value = default!;

                return true;
            }

            value = nullable.Value;

            return false;
        }
        
        public static bool IsNull<T>(this T? nullable, out T value)
            where T : class
        {
            if (nullable is null)
            {
                value = default!;

                return true;
            }

            value = nullable!;

            return false;
        }
    }
}