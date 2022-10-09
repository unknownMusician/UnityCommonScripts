using System;
using System.Collections;
using System.Collections.Generic;

namespace AreYouFruits.Common.Collections
{
    public static class GenericExtensions
    {
        private static readonly Random Random = new Random();

        public static TDictionary Foreach<TKey, TValue, TDictionary>(
            this TDictionary dictionary, Action<TKey, TValue> action
        )
            where TDictionary : IDictionary<TKey, TValue>
        {
            using IEnumerator<KeyValuePair<TKey,TValue>> enumerator = dictionary.GetEnumerator();

            while (enumerator.MoveNext())
            {
                (TKey key, TValue value) = enumerator.Current;
                
                action.Invoke(key, value);
            }
            
            return dictionary;
        }

        public static TEnumerable Foreach<T, TEnumerable>(this TEnumerable enumerable, Action<T> action)
            where TEnumerable : IEnumerable<T>
        {
            using IEnumerator<T> enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                action.Invoke(enumerator.Current);
            }

            return enumerable;
        }

        public static TEnumerable ForeachNonGeneric<TEnumerable>(this TEnumerable enumerable, Action<object?> action)
            where TEnumerable : IEnumerable
        {
            IEnumerator enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                action.Invoke(enumerator.Current);
            }
            
            return enumerable;
        }

        public static TReadOnlyList For<T, TReadOnlyList>(this TReadOnlyList list, Action<int, T> action)
            where TReadOnlyList : IReadOnlyList<T>
        {
            for (int i = 0; i < list.Count; i++)
            {
                action.Invoke(i, list[i]);
            }

            return list;
        }

        public static void SafeAddToValueCollection<TKey, TValue, TCollection, TDictionary>(
            this TDictionary dictionary, TKey key, TValue value
        )
            where TCollection : ICollection<TValue>, new()
            where TDictionary : IDictionary<TKey, TCollection>
        {
            if (!dictionary.TryGetValue(key, out TCollection valueList))
            {
                valueList = dictionary[key] = new TCollection();
            }

            valueList.Add(value);
        }

        public static int LastIndexOf<T, TReadOnlyList>(this TReadOnlyList list, T element)
            where TReadOnlyList : IReadOnlyList<T>
        {
            for (int i = list.Count - 1; i >= 0; i--)
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
            int randomIndex = Random.Next(0, list.Count);
            return list[randomIndex];
        }
    }
}