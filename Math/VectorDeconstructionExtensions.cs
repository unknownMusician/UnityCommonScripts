#if UNITY_2021_3

using UnityEngine;

namespace AreYouFruits.Common.Math
{
    public static class VectorDeconstructionExtensions
    {
        public static void Deconstruct(this Vector2 v, out float x, out float y)
        {
            (x, y) = (v.x, v.y);
        }

        public static void Deconstruct(this Vector3 v, out float x, out float y, out float z)
        {
            (x, y, z) = (v.x, v.y, v.z);
        }

        public static void Deconstruct(this Vector4 v, out float x, out float y, out float z, out float w)
        {
            (x, y, z, w) = (v.x, v.y, v.z, v.w);
        }

        public static void Deconstruct(this Vector2Int v, out int x, out int y)
        {
            (x, y) = (v.x, v.y);
        }

        public static void Deconstruct(this Vector3Int v, out int x, out int y, out int z)
        {
            (x, y, z) = (v.x, v.y, v.z);
        }
    }
}

#endif