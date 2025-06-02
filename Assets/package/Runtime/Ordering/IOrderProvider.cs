namespace AreYouFruits.Ordering
{
    public interface IOrderProvider<in T>
    {
        public int GetOrder(T value);
    }
}
