using System;
using System.Collections.Generic;
using AreYouFruits.Nullability;

namespace AreYouFruits.EventBus
{
    public sealed class TypedDictionary
    {
        private readonly Dictionary<Type, object> values = new();

        public int Count => values.Count;
        public ICollection<Type> Keys => values.Keys;
        public ICollection<object> Values => values.Values;
        
        public bool Add<T>(T value)
        {
            return values.TryAdd(typeof(T), value);
        }

        public bool AddNonGeneric(object value)
        {
            return values.TryAdd(value.GetType(), value);
        }

        public void Set<T>(T value)
        {
            values[typeof(T)] = value;
        }

        public void SetNonGeneric(object value)
        {
            values[value.GetType()] = value;
        }

        public Optional<T> Get<T>()
        {
            if (values.TryGetValue(typeof(T), out var result))
            {
                return Optional.Some((T)result);
            }

            return Optional.None();
        }

        public Optional<object> GetNonGeneric(Type type)
        {
            if (values.TryGetValue(type, out var result))
            {
                return Optional.Some(result);
            }

            return Optional.None();
        }

        public bool Contains<T>()
        {
            return values.ContainsKey(typeof(T));
        }

        public bool ContainsNonGeneric(Type type)
        {
            return values.ContainsKey(type);
        }
        
        public bool Remove<T>()
        {
            return values.Remove(typeof(T));
        }

        public bool RemoveNonGeneric(Type type)
        {
            return values.Remove(type);
        }
        
        public IEnumerator<object> GetEnumerator()
        {
            return values.Values.GetEnumerator();
        }
    }
}
