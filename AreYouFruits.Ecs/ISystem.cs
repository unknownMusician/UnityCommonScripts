namespace AreYouFruits.Ecs
{
    public interface ISystem
    {
        public void Execute(SystemContext ctx);
    }
}