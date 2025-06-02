using AreYouFruits.ConstructorGeneration;
using AreYouFruits.InitializerGeneration;
using AreYouFruits.ToStringGeneration;

namespace GeneratorsUseCases
{
    [GenerateToString, GeneratedInitializerName("Injeeeeeeeect")]
    public partial struct Player
    {
        [GenerateConstructor] public string Name;
        [GenerateInitializer] public int Age;
    }
}
