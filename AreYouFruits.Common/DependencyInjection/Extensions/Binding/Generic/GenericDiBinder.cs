using System;
using AreYouFruits.Common.DependencyInjection.Binders;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.TypeTransition;
using AreYouFruits.Common.DependencyInjection.Resolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.Generic
{
    public sealed class GenericDiBinder<TSource> : IGenericDiBinder<TSource>
    {
        private readonly IDiBinder binder;

        public GenericDiBinder(IDiBinder binder)
        {
            if (binder is null)
            {
                throw new ArgumentNullException(nameof(binder));
            }

            this.binder = binder;
        }

        public void To(IResolver<TSource> resolver)
        {
            binder.To(new ResolverObjectWrapper<TSource>(resolver));
        }

        public void To<TDestination>()
            where TDestination : TSource
        {
            binder.To(new TypeTransitionResolver(typeof(TDestination)));
        }
    }
}