using System;
using System.Collections.Generic;
using AreYouFruits.Nullability;

namespace AreYouFruits.Events
{
    public sealed class TypedDictionary
    {
        private readonly Dictionary<Type, object> values = new();

        public int Count => values.Count;
        public IReadOnlyCollection<Type> Keys => values.Keys;
        public IReadOnlyCollection<object> Values => values.Values;
        
        public bool AddVirtual(object value)
        {
            return values.TryAdd(value.GetType(), value);
        }

        public bool AddConcrete<T>(T value)
        {
            return values.TryAdd(typeof(T), value);
        }

        public bool AddConcrete(object value, Type type)
        {
            if (type.IsInstanceOfType(value))
            {
                return values.TryAdd(type, value);
            }

            return false;
        }

        public void SetVirtual(object value)
        {
            values[value.GetType()] = value;
        }

        public void SetConcrete<T>(T value)
        {
            values[typeof(T)] = value;
        }

        public Optional<T> Get<T>()
        {
            if (values.TryGetValue(typeof(T), out var result))
            {
                return Optional.Some((T)result);
            }

            return Optional.None();
        }

        public Optional<object> Get(Type type)
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

        public bool Contains(Type type)
        {
            return values.ContainsKey(type);
        }

        public bool RemoveVirtual(object value)
        {
            return values.Remove(value.GetType());
        }
        
        public bool RemoveConcrete<T>()
        {
            return values.Remove(typeof(T));
        }

        public bool RemoveConcrete(Type type)
        {
            return values.Remove(type);
        }
        
        public IEnumerator<object> GetEnumerator()
        {
            return values.Values.GetEnumerator();
        }
    }
    
    public sealed class TypedDictionary<TBase>
    {
        private readonly Dictionary<Type, TBase> values = new();

        public int Count => values.Count;
        public IReadOnlyCollection<Type> Keys => values.Keys;
        public IReadOnlyCollection<TBase> Values => values.Values;
        
        public bool AddVirtual(TBase value)
        {
            return values.TryAdd(value.GetType(), value);
        }

        public bool AddConcrete<T>(T value)
            where T : TBase
        {
            return values.TryAdd(typeof(T), value);
        }

        public bool AddConcrete(TBase value, Type type)
        {
            if (type.IsInstanceOfType(value))
            {
                return values.TryAdd(type, value);
            }

            return false;
        }

        public void SetVirtual(TBase value)
        {
            values[value.GetType()] = value;
        }

        public void SetConcrete<T>(T value)
            where T : TBase
        {
            values[typeof(T)] = value;
        }

        public Optional<T> Get<T>()
            where T : TBase
        {
            if (values.TryGetValue(typeof(T), out var result))
            {
                return Optional.Some((T)result);
            }

            return Optional.None();
        }

        public Optional<TBase> Get(Type type)
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

        public bool Contains(Type type)
        {
            return values.ContainsKey(type);
        }

        public bool RemoveVirtual(TBase value)
        {
            return values.Remove(value.GetType());
        }
        
        public bool RemoveConcrete<T>()
            where T : TBase
        {
            return values.Remove(typeof(T));
        }

        public bool RemoveConcrete(Type type)
        {
            return values.Remove(type);
        }
        
        public IEnumerator<TBase> GetEnumerator()
        {
            return values.Values.GetEnumerator();
        }
    }
}
