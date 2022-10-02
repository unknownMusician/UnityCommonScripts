#if UNITY_2021_3_OR_NEWER

using UnityEngine;

namespace AreYouFruits.Common.ComponentGeneration
{
    public static class AbstractComponentExtensions
    {
        public static T GetHeldItem<T>(this GameObject gameObject)
            where T : class
        {
            return gameObject.GetVarianceComponent<IComponent<T>>()!.HeldItem;
        }

        public static bool TryGetHeldItem<T>(this GameObject gameObject, out T heldItem)
            where T : class
        {
            IComponent<T>? component = gameObject.GetVarianceComponent<IComponent<T>>();

            if (component is null)
            {
                heldItem = null!;

                return false;
            }

            heldItem = component.HeldItem;

            return true;
        }
    }
}

#endif