using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic
{
    public static class DiContainerGenericExtensions
    {
        public static IGenericDiBinder<TSource> Bind<TSource>(this IDiContainer container)
        {
            return new GenericDiBinder<TSource>(container.Bind(typeof(TSource)));
        }

        public static void ClearBinding<TSource>(this IDiContainer container)
        {
            container.Clear(typeof(TSource));
        }
    }
}