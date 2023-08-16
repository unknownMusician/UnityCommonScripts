using System;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Extensions.Binding.TypeTransition;

// ReSharper disable once CheckNamespace
namespace AreYouFruits.DependencyInjection
{
    public static class DiBinderTypeTransitionResolverExtensions
    {
        public static void To(this IDiBinder binder, Type destinationType)
        {
            if (destinationType is null)
            {
                throw new ArgumentNullException(nameof(destinationType));
            }
            
            binder.To(new TypeTransitionResolver(destinationType));
        }
    }
}