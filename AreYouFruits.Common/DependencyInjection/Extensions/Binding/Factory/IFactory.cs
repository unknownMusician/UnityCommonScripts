namespace AreYouFruits.DependencyInjection
{
    public interface IFactory<out T>
    {
        public T Get();
    }
}