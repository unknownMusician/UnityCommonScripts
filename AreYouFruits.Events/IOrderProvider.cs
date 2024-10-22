namespace AreYouFruits.Events
{
    public interface IOrderProvider<in T>
    {
        public int GetOrder(T value);
    }
}
