using UnityEngine;

namespace AreYouFruits.VectorsSwizzling
{
    public static class SwizzlingVector4To2Extensions
    {
        // ReSharper disable once InconsistentNaming
        public static Vector2 XX(this Vector4 v) => new(v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector2 XY(this Vector4 v) => new(v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 XZ(this Vector4 v) => new(v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector2 XW(this Vector4 v) => new(v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector2 XN(this Vector4 v, float y = 0.0f) => new(v.x, y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 YX(this Vector4 v) => new(v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector2 ZX(this Vector4 v) => new(v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector2 WX(this Vector4 v) => new(v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector2 NX(this Vector4 v, float x = 0.0f) => new(x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector2 YY(this Vector4 v) => new(v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 ZY(this Vector4 v) => new(v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 WY(this Vector4 v) => new(v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 NY(this Vector4 v, float x = 0.0f) => new(x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 YZ(this Vector4 v) => new(v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector2 ZZ(this Vector4 v) => new(v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector2 WZ(this Vector4 v) => new(v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector2 NZ(this Vector4 v, float x = 0.0f) => new(x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector2 YW(this Vector4 v) => new(v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector2 ZW(this Vector4 v) => new(v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector2 WW(this Vector4 v) => new(v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector2 NW(this Vector4 v, float x = 0.0f) => new(x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector2 YN(this Vector4 v, float y = 0.0f) => new(v.y, y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 ZN(this Vector4 v, float y = 0.0f) => new(v.z, y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 WN(this Vector4 v, float y = 0.0f) => new(v.w, y);
    }
}
