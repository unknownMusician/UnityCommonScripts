#if UNITY_2021_3

using System.Linq;
using UnityEngine;

namespace AreYouFruits.Common
{
    public static class TransformExtensions
    {
        public static Transform[] GetChildren(this Transform transform)
        {
            return transform.Cast<Transform>().ToArray();
        }
    }
}

#endif