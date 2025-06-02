using System;
using System.Collections.Generic;
using AreYouFruits.Nullability;

namespace AreYouFruits.ExternalPolymorphism
{
    public sealed class VirtualAction<TBase>
    {
        private readonly Dictionary<Type, Action<TBase>> registrations = new();
        
        public void Register<T>(Action<T> action)
            where T : TBase
        {
            registrations.Add(typeof(T), v => action((T)v));
        }

        public bool Invoke<T>(T value)
            where T : TBase
        {
            var type = typeof(T).IsSealed switch
            {
                true => typeof(T),
                false => value.GetType(),
            };
            
            if (!registrations.TryGetValue(type, out var action))
            {
                return false;
            }

            action(value);
            
            return true;
        }

        public Optional<Action<T>> Get<T>(T value)
            where T : TBase
        {
            var type = typeof(T).IsSealed switch
            {
                true => typeof(T),
                false => value.GetType(),
            };
            
            if (!registrations.TryGetValue(type, out var action))
            {
                return Optional.None();
            }

            return Optional.Some<Action<T>>(v => action(v));
        }
    }
}
