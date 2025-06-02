using UnityEngine;

namespace AreYouFruits.VectorsSwizzling
{
    public static class SwizzlingVector3To2Extensions
    {
        // ReSharper disable once InconsistentNaming
        public static Vector2 XX(this Vector3 v) => new(v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector2 XY(this Vector3 v) => new(v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 XZ(this Vector3 v) => new(v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector2 XN(this Vector3 v, float y = 0.0f) => new(v.x, y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 YX(this Vector3 v) => new(v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector2 ZX(this Vector3 v) => new(v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector2 NX(this Vector3 v, float x = 0.0f) => new(x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector2 YY(this Vector3 v) => new(v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 ZY(this Vector3 v) => new(v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 NY(this Vector3 v, float x = 0.0f) => new(x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 YZ(this Vector3 v) => new(v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector2 ZZ(this Vector3 v) => new(v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector2 NZ(this Vector3 v, float x = 0.0f) => new(x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector2 YN(this Vector3 v, float y = 0.0f) => new(v.y, y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 ZN(this Vector3 v, float y = 0.0f) => new(v.z, y);
    }
}
