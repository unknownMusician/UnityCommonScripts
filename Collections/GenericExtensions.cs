using System;
using System.Collections;
using System.Collections.Generic;

namespace AreYouFruits.Common.Collections
{
    public static class GenericExtensions
    {
        private static readonly Random Random = new();

        public static TDictionary Foreach<TKey, TValue, TDictionary>(
            this TDictionary dictionary, Action<TKey, TValue> action
        )
            where TDictionary : IDictionary<TKey, TValue>
        {
            foreach ((TKey key, TValue value) in dictionary)
            {
                action.Invoke(key, value);
            }

            return dictionary;
        }

        public static TEnumerable Foreach<T, TEnumerable>(this TEnumerable collection, Action<T> action)
            where TEnumerable : IEnumerable<T>
        {
            foreach (T element in collection)
            {
                action.Invoke(element);
            }

            return collection;
        }

        public static TEnumerable ForeachNonGeneric<TEnumerable>(this TEnumerable collection, Action<object> action)
            where TEnumerable : IEnumerable
        {
            foreach (object element in collection)
            {
                action.Invoke(element);
            }

            return collection;
        }

        public static TReadOnlyCollection For<T, TReadOnlyCollection>(
            this TReadOnlyCollection array, Action<int> action
        )
            where TReadOnlyCollection : IReadOnlyCollection<T>
        {
            for (int i = 0; i < array.Count; i++)
            {
                action.Invoke(i);
            }

            return array;
        }

        public static TReadOnlyList For<T, TReadOnlyList>(this TReadOnlyList array, Action<int, T> action)
            where TReadOnlyList : IReadOnlyList<T>
        {
            for (int i = 0; i < array.Count; i++)
            {
                action.Invoke(i, array[i]);
            }

            return array;
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