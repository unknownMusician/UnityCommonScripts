using System;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Extensions.Binding.TypeTransition;
using AreYouFruits.DependencyInjection.Resolvers;

namespace AreYouFruits.DependencyInjection.Extensions.Binding.Generic
{
    public sealed class GenericDiBinder<TSource> : IGenericDiBinder<TSource>
    {
        private readonly IDiBinder _binder;

        public GenericDiBinder(IDiBinder binder)
        {
            if (binder is null)
            {
                throw new ArgumentNullException(nameof(binder));
            }

            _binder = binder;
        }

        public void To(IResolver<TSource> resolver)
        {
            _binder.To(new ResolverObjectWrapper<TSource>(resolver));
        }

        public void To<TDestination>()
            where TDestination : TSource
        {
            _binder.To(new TypeTransitionResolver<TSource, TDestination>());
        }
    }
}