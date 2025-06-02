using UnityEngine;

namespace AreYouFruits.VectorsSwizzling
{
    public static class SwizzlingVector2To2Extensions
    {
        // ReSharper disable once InconsistentNaming
        public static Vector2 XX(this Vector2 v) => new(v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector2 XY(this Vector2 v) => new(v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 XN(this Vector2 v, float y = 0.0f) => new(v.x, y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 YX(this Vector2 v) => new(v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector2 NX(this Vector2 v, float x = 0.0f) => new(x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector2 YY(this Vector2 v) => new(v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 NY(this Vector2 v, float x = 0.0f) => new(x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector2 YN(this Vector2 v, float y = 0.0f) => new(v.y, y);
    }
}
