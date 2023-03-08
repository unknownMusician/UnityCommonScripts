namespace AreYouFruits.DependencyInjection
{
    public interface IConverter<in TSource, out TDestination>
    {
        public TDestination Convert(TSource value);
    }
}