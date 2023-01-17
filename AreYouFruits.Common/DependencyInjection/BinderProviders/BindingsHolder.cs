using System;
using System.Collections.Generic;
using AreYouFruits.DependencyInjection.Binders;
using AreYouFruits.DependencyInjection.Exceptions;

namespace AreYouFruits.DependencyInjection.BinderProviders
{
    public sealed class BindingsHolder : IBindingsHolder
    {
        private readonly object _locker = new object();
        private readonly Dictionary<Type, IDiBinding> _binders = new Dictionary<Type, IDiBinding>();

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

            lock (_locker)
            {
                if (!_binders.TryAdd(type, binding))
                {
                    throw new BindingCollisionException(type);
                }
            }
        }

        public IDiBinding Get(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            lock (_locker)
            {
                return _binders[type];
            }
        }

        public void TryRemove(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            lock (_locker)
            {
                _binders.Remove(type);
            }
        }
    }
}