using UnityEngine;

namespace AreYouFruits.VectorsSwizzling
{
    public static class SwizzlingVector2To3Extensions
    {
        public static Vector3 XXX(this Vector2 v) => new(v.x, v.x, v.x);
        public static Vector3 XXY(this Vector2 v) => new(v.x, v.x, v.y);
        public static Vector3 XXN(this Vector2 v, float z = 0.0f) => new(v.x, v.x, z);
        public static Vector3 XYX(this Vector2 v) => new(v.x, v.y, v.x);
        public static Vector3 XNX(this Vector2 v, float y = 0.0f) => new(v.x, y, v.x);
        public static Vector3 XYY(this Vector2 v) => new(v.x, v.y, v.y);
        public static Vector3 XNY(this Vector2 v, float y = 0.0f) => new(v.x, y, v.y);
        public static Vector3 XYN(this Vector2 v, float z = 0.0f) => new(v.x, v.y, z);
        public static Vector3 XNN(this Vector2 v, float y = 0.0f, float z = 0.0f) => new(v.x, y, z);
        public static Vector3 YXX(this Vector2 v) => new(v.y, v.x, v.x);
        public static Vector3 NXX(this Vector2 v, float x = 0.0f) => new(x, v.x, v.x);
        public static Vector3 YXY(this Vector2 v) => new(v.y, v.x, v.y);
        public static Vector3 NXY(this Vector2 v, float x = 0.0f) => new(x, v.x, v.y);
        public static Vector3 YXN(this Vector2 v, float z = 0.0f) => new(v.y, v.x, z);
        public static Vector3 NXN(this Vector2 v, float x = 0.0f, float z = 0.0f) => new(x, v.x, z);
        public static Vector3 YYX(this Vector2 v) => new(v.y, v.y, v.x);
        public static Vector3 NYX(this Vector2 v, float x = 0.0f) => new(x, v.y, v.x);
        public static Vector3 YNX(this Vector2 v, float y = 0.0f) => new(v.y, y, v.x);
        public static Vector3 NNX(this Vector2 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.x);
        public static Vector3 YYY(this Vector2 v) => new(v.y, v.y, v.y);
        public static Vector3 NYY(this Vector2 v, float x = 0.0f) => new(x, v.y, v.y);
        public static Vector3 YNY(this Vector2 v, float y = 0.0f) => new(v.y, y, v.y);
        public static Vector3 NNY(this Vector2 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.y);
        public static Vector3 YYN(this Vector2 v, float z = 0.0f) => new(v.y, v.y, z);
        public static Vector3 NYN(this Vector2 v, float x = 0.0f, float z = 0.0f) => new(x, v.y, z);
        public static Vector3 YNN(this Vector2 v, float y = 0.0f, float z = 0.0f) => new(v.y, y, z);
    }
}
