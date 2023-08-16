namespace AreYouFruits.DependencyInjection.Extensions.Binding.Conversion
{
    public interface IConverter<in TSource, out TDestination>
    {
        public TDestination Convert(TSource value);
    }
}