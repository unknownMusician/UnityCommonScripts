using AreYouFruits.ToStringGeneration;

namespace GeneratorsUseCases
{
    [GenerateToString]
    public partial struct Player
    {
        public string Name;
        public int Age;
    }
}
