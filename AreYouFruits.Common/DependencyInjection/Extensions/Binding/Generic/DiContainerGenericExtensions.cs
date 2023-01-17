using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Extensions.Binding.Generic;

namespace AreYouFruits.DependencyInjection
{
    public static class DiContainerGenericExtensions
    {
        public static IGenericDiBinder<TSource> Bind<TSource>(this IDiContainer container)
        {
            return new GenericDiBinder<TSource>(container.Bind(typeof(TSource)));
        }

        public static void ClearBinding<TSource>(this IDiContainer container)
        {
            container.ClearBinding(typeof(TSource));
        }
    }
}