using AreYouFruits.ConstructorGeneration;
using AreYouFruits.ToStringGeneration;

namespace GeneratorsUseCases
{
    [GenerateToString]
    public partial class Person
    {
        [GenerateConstructor] private readonly string name;
        public readonly Person Parent;

        private Person()
        {
            Parent = this;
        }
    }
}
