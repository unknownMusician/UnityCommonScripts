namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.Factory
{
    public interface IFactory<out T>
    {
        public T Get();
    }
}