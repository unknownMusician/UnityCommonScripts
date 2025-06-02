using System;
using System.Collections.Generic;
using AreYouFruits.Nullability;

namespace AreYouFruits.ExternalPolymorphism
{
    public sealed class VirtualFunc<TBase, TResult>
    {
        private readonly Dictionary<Type, Func<TBase, TResult>> registrations = new();
        
        public void Register<T>(Func<T, TResult> func)
            where T : TBase
        {
            registrations.Add(typeof(T), v => func((T)v));
        }

        public Optional<TResult> Invoke<T>(T value)
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

            return action(value);
        }

        public Optional<Func<T, TResult>> Get<T>(T value)
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

            return Optional.Some<Func<T, TResult>>(v => action(v));
        }
    }
}
