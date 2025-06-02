namespace AreYouFruits.Nullability
{
    public partial struct Optional<T>
    {
        private T value;
        private bool isInitialized;
    }
}
