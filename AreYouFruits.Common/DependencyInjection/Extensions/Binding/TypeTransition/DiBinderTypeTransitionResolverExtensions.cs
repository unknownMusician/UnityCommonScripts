using System;
using AreYouFruits.Common.DependencyInjection.Binders;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.TypeTransition
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