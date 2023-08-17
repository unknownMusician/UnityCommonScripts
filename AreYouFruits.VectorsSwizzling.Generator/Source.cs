namespace AreYouFruits.VectorsSwizzling.Generator
{
    public sealed class Source
    {
        public string Name { get; }
        public string Content { get; }

        public Source(string name, string content)
        {
            Name = name;
            Content = content;
        }
    }
}
