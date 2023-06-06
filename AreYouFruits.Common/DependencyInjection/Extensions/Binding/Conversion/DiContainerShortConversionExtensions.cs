using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.Conversion
{
    public static class DiContainerShortConversionExtensions
    {
        public static void BindToConversion<TSource, TDestination>(
            this IDiContainer container, IConverter<TDestination, TSource> converter
        )
        {
            container.Bind<TSource>().ToConversion(converter);
        }
    }
}