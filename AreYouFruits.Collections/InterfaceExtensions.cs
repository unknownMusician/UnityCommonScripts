using System;
using System.Collections;
using System.Collections.Generic;

namespace AreYouFruits.Collections
{
    public static class InterfaceExtensions
    {
        private static readonly Random Random = new Random();

        public static IDictionary<TKey, TValue> Foreach<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, Action<TKey, TValue> action
        )
        {
            return dictionary.Foreach<TKey, TValue, IDictionary<TKey, TValue>>(action);
        }

        public static IEnumerable<T> Foreach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            return collection.Foreach<T, IEnumerable<T>>(action);
        }

        public static IEnumerable ForeachNonGeneric(this IEnumerable collection, Action<object> action)
        {
            return collection.ForeachNonGeneric<IEnumerable>(action);
        }

        public static IReadOnlyList<T> For<T>(this IReadOnlyList<T> array, Action<int, T> action)
        {
            return array.For<T, IReadOnlyList<T>>(action);
        }

        public static void SafeAddToValueCollection<TKey, TValue, TCollection>(
            this IDictionary<TKey, TCollection> dictionary, TKey key, TValue value
        ) where TCollection : ICollection<TValue>, new()
        {
            dictionary.SafeAddToValueCollection<TKey, TValue, TCollection, IDictionary<TKey, TCollection>>(key, value);
        }
        
        public static int LastIndexOf<T>(this IReadOnlyList<T> collection, T element)
        {
            return collection.LastIndexOf<T, IReadOnlyList<T>>(element);
        }
        
        public static T GetRandomElement<T>(this IReadOnlyList<T> array)
        {
            return array.GetRandomElement<T, IReadOnlyList<T>>();
        }
    }
}
