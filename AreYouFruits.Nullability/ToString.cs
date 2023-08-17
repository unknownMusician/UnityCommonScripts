namespace AreYouFruits.Nullability
{
    public partial struct Optional<T>
    {
        public override string ToString()
        {
            string valueString = (isInitialized, value) switch
            {
                (true, not null) => value.ToString(),
                _ => "Null",
            };

            return $"Optional {{ {valueString} }}";
        }
    }
}
