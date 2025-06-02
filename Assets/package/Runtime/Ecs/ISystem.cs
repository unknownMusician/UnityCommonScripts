using AreYouFruits.Nullability;

namespace AreYouFruits.Ecs
{
    public interface ISystem
    {
        public Optional<SystemDataUsage> TryGetDataUsage() => Optional.None();
        public void Execute(SystemContext ctx);
    }
}