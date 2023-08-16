using System;
using System.Collections.Generic;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Exceptions;

namespace AreYouFruits.DependencyInjection.BinderProviders
{
    public sealed class BindingsHolder : IBindingsHolder
    {
        private readonly object locker = new();
        private readonly Dictionary<Type, IDiBinding> binders = new();

        public void Add(IDiBinding binding)
        {
            if (binding is null)
            {
                throw new ArgumentNullException(nameof(binding));
            }

            Type type = binding.SourceType;

            if (type is null)
            {
                throw new ArgumentNullException(nameof(binding.SourceType));
            }

            lock (locker)
            {
                if (!binders.TryAdd(type, binding))
                {
                    throw new BindingCollisionException(type);
                }
            }
        }

        public bool TryGet(Type type, out IDiBinding binding)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            lock (locker)
            {
                return binders.TryGetValue(type, out binding);
            }
        }

        public void TryRemove(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            lock (locker)
            {
                binders.Remove(type);
            }
        }
    }
}