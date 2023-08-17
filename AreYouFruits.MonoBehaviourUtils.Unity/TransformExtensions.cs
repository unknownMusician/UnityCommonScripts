using System.Linq;
using UnityEngine;

namespace AreYouFruits.MonoBehaviourUtils.Unity
{
    public static class TransformExtensions
    {
        public static Transform[] GetChildren(this Transform transform)
        {
            return transform.Cast<Transform>().ToArray();
        }
    }
}

