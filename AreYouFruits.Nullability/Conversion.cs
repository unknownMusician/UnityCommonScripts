namespace AreYouFruits.Nullability
{
    public partial struct Optional<T>
    {
        public Optional<TOther> As<TOther>()
        {
            if (!isInitialized || value is not TOther other)
            {
                return default;
            }

            return other;
        }
    }
}
