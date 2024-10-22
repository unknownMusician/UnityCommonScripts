using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AreYouFruits.Collections
{
    public static class InterfaceExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue newValue
        )
        {
            return GenericExtensions.GetOrAdd(dictionary, key, newValue);
        }

        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TValue> factory
        )
        {
            return GenericExtensions.GetOrAdd(dictionary, key, factory);
        }

        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TKey, TValue> factory
        )
        {
            return GenericExtensions.GetOrAdd(dictionary, key, factory);
        }
        
        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key
        )
            where TValue : new()
        {
            return GenericExtensions.GetOrAdd<TKey, TValue, IDictionary<TKey, TValue>>(dictionary, key);
        }
        
        public static IDictionary<TKey, TValue> Foreach<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, Action<TKey, TValue> action
        )
        {
            return GenericExtensions.Foreach(dictionary, action);
        }

        public static IEnumerable<T> Foreach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            return GenericExtensions.Foreach(collection, action);
        }

        public static IEnumerable ForeachNonGeneric(this IEnumerable collection, Action<object> action)
        {
            return GenericExtensions.ForeachNonGeneric(collection, action);
        }

        public static IReadOnlyList<T> For<T>(this IReadOnlyList<T> array, Action<int, T> action)
        {
            return GenericExtensions.For(array, action);
        }

        public static TValue GetOrInsert<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> factory
        )
        {
            return GenericExtensions.GetOrInsert(dictionary, key, factory);
        }

        public static TValue GetOrInsertNew<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, TKey key
        )
            where TValue : new()
        {
            return GenericExtensions.GetOrInsertNew<TKey, TValue, IDictionary<TKey, TValue>>(dictionary, key);
        }

        public static bool RemoveFromValueCollectionOrRemoveValue<TKey, TValue, TCollection>(
            this IDictionary<TKey, TCollection> dictionary, TKey key, TValue value
        )
            where TCollection : ICollection<TValue>, new()
        {
            return GenericExtensions.RemoveFromValueCollectionOrRemoveValue
                <TKey, TValue, TCollection, IDictionary<TKey, TCollection>>
                (dictionary, key, value);
        }

        public static bool RemoveFromValueDictionaryOrRemoveValue<TKey, TInnerKey, TInnerValue, TInnerDictionary>(
            this IDictionary<TKey, TInnerDictionary> dictionary, TKey key, TInnerKey innerKey
        )
            where TInnerDictionary : IDictionary<TInnerKey, TInnerValue>, new()
        {
            return GenericExtensions.RemoveFromValueDictionaryOrRemoveValue
                <TKey, TInnerKey, TInnerValue, TInnerDictionary, IDictionary<TKey, TInnerDictionary>>
                (dictionary, key, innerKey);
        }
        
        public static int LastIndexOf<T>(this IReadOnlyList<T> collection, T element)
        {
            return GenericExtensions.LastIndexOf(collection, element);
        }
        
        public static T GetRandomElement<T>(this IReadOnlyList<T> array)
        {
            return GenericExtensions.GetRandomElement<T, IReadOnlyList<T>>(array);
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary)
        {
            return new Dictionary<TKey, TValue>(dictionary);
        }
    }
}
