namespace AreYouFruits.Nullability
{
    public partial struct Optional<T>
    {
        public readonly override string ToString()
        {
            string valueString = (isInitialized, value) switch
            {
                (true, not null) => value.ToString(),
                _ => "Null",
            };

            return $"Optional<{typeof(T).Name}> {{ {valueString} }}";
        }
    }
}
