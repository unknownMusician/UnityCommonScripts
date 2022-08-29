#if UNITY_2021_3

using UnityEngine;

namespace AreYouFruits.Common.Math
{
    public static class SnapExtensions
    {
        public static Vector2 SnappedToGrid(this Vector2 v)
        {
            return new Vector2(Mathf.Round(v.x + 0.5f) - 0.5f, Mathf.Round(v.y + 0.5f) - 0.5f);
        }

        public static Vector3 SnappedToGrid(this Vector3 v, bool keepY)
        {
            return new Vector3(Mathf.Round(v.x + 0.5f) - 0.5f, keepY ? v.y : 0, Mathf.Round(v.z + 0.5f) - 0.5f);
        }

        public static Vector3 SnappedToGrid(this Vector3 v, float newY)
        {
            return new Vector3(Mathf.Round(v.x + 0.5f) - 0.5f, newY, Mathf.Round(v.z + 0.5f) - 0.5f);
        }
    }
}

#endif