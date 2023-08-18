using AreYouFruits.ConstructorGeneration;
using AreYouFruits.ToStringGeneration;

namespace GeneratorsUseCases
{
    [GenerateToString]
    public partial struct Player
    {
        [GenerateConstructor] public string Name;
        [GenerateConstructor] public int Age;
    }
}
