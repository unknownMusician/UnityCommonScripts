using System;
using System.Linq;
using AreYouFruits.Nullability;
using UnityEngine;

namespace AreYouFruits.MonoBehaviourUtils.Unity
{
    public static class ComponentExtensions
        // todo: check for covariance to optimize
    {
        public static T GetComponentOrThrow<T>(this GameObject obj)
        {
            if (!obj.TryGetComponent(out T component))
            {
                throw new ArgumentException($"No component of type ({typeof(T)}) on GameObject.");
            }

            return component;
        }

        public static void GetVarianceComponents<T1>(this GameObject gameObject, out Optional<T1> c1)
            where T1 : class
        {
            c1 = gameObject.GetVarianceComponent<T1>();
        }

        public static void GetVarianceComponents<T1, T2>(
            this GameObject gameObject,
            out Optional<T1> c1,
            out Optional<T2> c2
        )
            where T1 : class
            where T2 : class
        {
            gameObject.GetVarianceComponents(out c1);
            c2 = gameObject.GetVarianceComponent<T2>();
        }

        public static void GetVarianceComponents<T1, T2, T3>(
            this GameObject gameObject,
            out Optional<T1> c1,
            out Optional<T2> c2,
            out Optional<T3> c3
        )
            where T1 : class
            where T2 : class
            where T3 : class
        {
            gameObject.GetVarianceComponents(out c1, out c2);
            gameObject.GetVarianceComponents(out c3);
        }

        public static void GetVarianceComponents<T1, T2, T3, T4>(
            this GameObject gameObject,
            out Optional<T1> c1,
            out Optional<T2> c2,
            out Optional<T3> c3,
            out Optional<T4> c4
        )
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            gameObject.GetVarianceComponents(out c1, out c2, out c3);
            gameObject.GetVarianceComponents(out c4);
        }

        public static void GetComponents<T1, T2, T3, T4, T5>(
            this GameObject gameObject,
            out Optional<T1> c1,
            out Optional<T2> c2,
            out Optional<T3> c3,
            out Optional<T4> c4,
            out Optional<T5> c5
        )
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            gameObject.GetVarianceComponents(out c1, out c2, out c3, out c4);
            gameObject.GetVarianceComponents(out c5);
        }

        public static Component[] GetAllComponents(this GameObject obj) => obj.GetComponents<Component>();

        public static T[] GetVarianceComponents<T>(this GameObject obj)
            where T : class
        {
            return obj.GetAllComponents().Where(c => c is T).Cast<T>().ToArray();
        }

        public static Component[] GetVarianceComponents(this GameObject obj, Type type)
        {
            return obj.GetAllComponents().Where(type.IsInstanceOfType).ToArray();
        }

        public static Optional<T> GetVarianceComponent<T>(this GameObject gameObject)
            where T : class
        {
            if (!gameObject.GetVarianceComponent(typeof(T)).TryGet(out Component component))
            {
                return default;
            }

            return (T)(object)component;
        }

        public static Optional<Component> GetVarianceComponent(this GameObject gameObject, Type type)
        {
            Optional<Component> result = default;

            foreach (Component component in gameObject.GetAllComponents())
            {
                if (!type.IsInstanceOfType(component))
                {
                    continue;
                }

                if (result.IsInitialized)
                {
                    throw new InvalidOperationException();
                }

                result = component;
            }

            return result;
        }
    }
}
