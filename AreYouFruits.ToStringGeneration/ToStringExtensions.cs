namespace AreYouFruits.ToStringGeneration
{
    public static class ToStringExtensions
    {
        public static string ToStringUniversal<T>(this T value)
        {
            return value?.ToString() ?? "Null";
        }
    }
}
