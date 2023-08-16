using AreYouFruits.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.DependencyInjection.TypeResolvers;

// ReSharper disable once CheckNamespace
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
            container.Clear(typeof(TSource));
        }
    }
}