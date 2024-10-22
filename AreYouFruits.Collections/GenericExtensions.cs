using System;
using System.Collections;
using System.Collections.Generic;

namespace AreYouFruits.Collections
{
    public static class GenericExtensions
    {
        private static readonly Random Random = new();

        public static TValue GetOrAdd<TKey, TValue, TDictionary>(
            this TDictionary dictionary,
            TKey key,
            TValue newValue
        )
            where TDictionary : IDictionary<TKey, TValue>
        {
            if (!dictionary.TryGetValue(key, out var value))
            {
                value = newValue;
                dictionary.Add(key, value);
            }

            return value;
        }

        public static TValue GetOrAdd<TKey, TValue, TDictionary>(
            this TDictionary dictionary,
            TKey key,
            Func<TValue> factory
        )
            where TDictionary : IDictionary<TKey, TValue>
        {
            if (!dictionary.TryGetValue(key, out var value))
            {
                value = factory();
                dictionary.Add(key, value);
            }

            return value;
        }

        public static TValue GetOrAdd<TKey, TValue, TDictionary>(
            this TDictionary dictionary,
            TKey key,
            Func<TKey, TValue> factory
        )
            where TDictionary : IDictionary<TKey, TValue>
        {
            if (!dictionary.TryGetValue(key, out var value))
            {
                value = factory(key);
                dictionary.Add(key, value);
            }

            return value;
        }

        public static TValue GetOrAdd<TKey, TValue, TDictionary>(
            this TDictionary dictionary,
            TKey key
        )
            where TDictionary : IDictionary<TKey, TValue>
            where TValue : new()
        {
            return dictionary.GetOrAdd<TKey, TValue, TDictionary>(key, static () => new());
        }

        public static TDictionary Foreach<TKey, TValue, TDictionary>(
            this TDictionary dictionary, Action<TKey, TValue> action
        )
            where TDictionary : IDictionary<TKey, TValue>
        {
            using var enumerator = dictionary.GetEnumerator();

            while (enumerator.MoveNext())
            {
                (var key, var value) = enumerator.Current;
                
                action.Invoke(key, value);
            }
            
            return dictionary;
        }

        public static TEnumerable Foreach<T, TEnumerable>(this TEnumerable enumerable, Action<T> action)
            where TEnumerable : IEnumerable<T>
        {
            using var enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                action.Invoke(enumerator.Current);
            }

            return enumerable;
        }

        public static TEnumerable ForeachNonGeneric<TEnumerable>(this TEnumerable enumerable, Action<object?> action)
            where TEnumerable : IEnumerable
        {
            var enumerator = enumerable.GetEnumerator();
            using var disposable = enumerator as IDisposable;

            while (enumerator.MoveNext())
            {
                action.Invoke(enumerator.Current);
            }
            
            return enumerable;
        }

        public static TReadOnlyList For<T, TReadOnlyList>(this TReadOnlyList list, Action<int, T> action)
            where TReadOnlyList : IReadOnlyList<T>
        {
            for (var i = 0; i < list.Count; i++)
            {
                action.Invoke(i, list[i]);
            }

            return list;
        }

        public static TValue GetOrInsert<TKey, TValue, TDictionary>(
            this TDictionary dictionary, TKey key, Func<TKey, TValue> factory
        )
            where TDictionary : IDictionary<TKey, TValue>
        {
            if (!dictionary.TryGetValue(key, out var value))
            {
                value = factory(key);
                dictionary.Add(key, value);
            }

            return value;
        }

        public static TValue GetOrInsertNew<TKey, TValue, TDictionary>(this TDictionary dictionary, TKey key)
            where TDictionary : IDictionary<TKey, TValue>
            where TValue : new()
        {
            return GetOrInsert(dictionary, key, static _ => new TValue());
        }

        public static bool RemoveFromValueCollectionOrRemoveValue<TKey, TValue, TCollection, TDictionary>(
            this TDictionary dictionary, TKey key, TValue value
        )
            where TCollection : ICollection<TValue>, new()
            where TDictionary : IDictionary<TKey, TCollection>
        {
            if (!dictionary.TryGetValue(key, out var collection))
            {
                return false;
            }

            if (!collection.Remove(value))
            {
                return false;
            }

            if (collection.Count is 0)
            {
                dictionary.Remove(key);
            }

            return true;
        }

        public static bool RemoveFromValueDictionaryOrRemoveValue<TKey, TInnerKey, TInnerValue, TInnerDictionary, TDictionary>(
            this TDictionary dictionary, TKey key, TInnerKey innerKey
        )
            where TInnerDictionary : IDictionary<TInnerKey, TInnerValue>, new()
            where TDictionary : IDictionary<TKey, TInnerDictionary>
        {
            if (!dictionary.TryGetValue(key, out var innerDictionary))
            {
                return false;
            }

            if (!innerDictionary.Remove(innerKey))
            {
                return false;
            }

            if (innerDictionary.Count is 0)
            {
                dictionary.Remove(key);
            }

            return true;
        }

        public static int LastIndexOf<T, TReadOnlyList>(this TReadOnlyList list, T element)
            where TReadOnlyList : IReadOnlyList<T>
        {
            for (var i = list.Count - 1; i >= 0; i--)
            {
                if (EqualityComparer<T>.Default.Equals(list[i], element))
                {
                    return i;
                }
            }

            return -1;
        }

        public static T GetRandomElement<T, TReadOnlyList>(this TReadOnlyList list)
            where TReadOnlyList : IReadOnlyList<T>
        {
            var randomIndex = Random.Next(0, list.Count);
            return list[randomIndex];
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue, TEnumerable>(this TEnumerable dictionary)
            where TEnumerable : IEnumerable<KeyValuePair<TKey, TValue>>
        {
            var result = new Dictionary<TKey, TValue>();

            foreach (var (key, value) in dictionary)
            {
                result.Add(key, value);
            }

            return result;
        }
    }
}