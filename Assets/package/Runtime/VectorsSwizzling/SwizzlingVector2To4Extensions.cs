using UnityEngine;

namespace AreYouFruits.VectorsSwizzling
{
    public static class SwizzlingVector2To4Extensions
    {
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXXX(this Vector2 v) => new(v.x, v.x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXXY(this Vector2 v) => new(v.x, v.x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXXN(this Vector2 v, float w = 0.0f) => new(v.x, v.x, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXYX(this Vector2 v) => new(v.x, v.x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXNX(this Vector2 v, float z = 0.0f) => new(v.x, v.x, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXYY(this Vector2 v) => new(v.x, v.x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXNY(this Vector2 v, float z = 0.0f) => new(v.x, v.x, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXYN(this Vector2 v, float w = 0.0f) => new(v.x, v.x, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXNN(this Vector2 v, float z = 0.0f, float w = 0.0f) => new(v.x, v.x, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYXX(this Vector2 v) => new(v.x, v.y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNXX(this Vector2 v, float y = 0.0f) => new(v.x, y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYXY(this Vector2 v) => new(v.x, v.y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNXY(this Vector2 v, float y = 0.0f) => new(v.x, y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYXN(this Vector2 v, float w = 0.0f) => new(v.x, v.y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNXN(this Vector2 v, float y = 0.0f, float w = 0.0f) => new(v.x, y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYYX(this Vector2 v) => new(v.x, v.y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNYX(this Vector2 v, float y = 0.0f) => new(v.x, y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYNX(this Vector2 v, float z = 0.0f) => new(v.x, v.y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNNX(this Vector2 v, float y = 0.0f, float z = 0.0f) => new(v.x, y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYYY(this Vector2 v) => new(v.x, v.y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNYY(this Vector2 v, float y = 0.0f) => new(v.x, y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYNY(this Vector2 v, float z = 0.0f) => new(v.x, v.y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNNY(this Vector2 v, float y = 0.0f, float z = 0.0f) => new(v.x, y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYYN(this Vector2 v, float w = 0.0f) => new(v.x, v.y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNYN(this Vector2 v, float y = 0.0f, float w = 0.0f) => new(v.x, y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYNN(this Vector2 v, float z = 0.0f, float w = 0.0f) => new(v.x, v.y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNNN(this Vector2 v, float y = 0.0f, float z = 0.0f, float w = 0.0f) => new(v.x, y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXXX(this Vector2 v) => new(v.y, v.x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXXX(this Vector2 v, float x = 0.0f) => new(x, v.x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXXY(this Vector2 v) => new(v.y, v.x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXXY(this Vector2 v, float x = 0.0f) => new(x, v.x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXXN(this Vector2 v, float w = 0.0f) => new(v.y, v.x, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXXN(this Vector2 v, float x = 0.0f, float w = 0.0f) => new(x, v.x, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXYX(this Vector2 v) => new(v.y, v.x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXYX(this Vector2 v, float x = 0.0f) => new(x, v.x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXNX(this Vector2 v, float z = 0.0f) => new(v.y, v.x, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXNX(this Vector2 v, float x = 0.0f, float z = 0.0f) => new(x, v.x, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXYY(this Vector2 v) => new(v.y, v.x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXYY(this Vector2 v, float x = 0.0f) => new(x, v.x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXNY(this Vector2 v, float z = 0.0f) => new(v.y, v.x, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXNY(this Vector2 v, float x = 0.0f, float z = 0.0f) => new(x, v.x, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXYN(this Vector2 v, float w = 0.0f) => new(v.y, v.x, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXYN(this Vector2 v, float x = 0.0f, float w = 0.0f) => new(x, v.x, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXNN(this Vector2 v, float z = 0.0f, float w = 0.0f) => new(v.y, v.x, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXNN(this Vector2 v, float x = 0.0f, float z = 0.0f, float w = 0.0f) => new(x, v.x, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYXX(this Vector2 v) => new(v.y, v.y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYXX(this Vector2 v, float x = 0.0f) => new(x, v.y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNXX(this Vector2 v, float y = 0.0f) => new(v.y, y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNXX(this Vector2 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYXY(this Vector2 v) => new(v.y, v.y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYXY(this Vector2 v, float x = 0.0f) => new(x, v.y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNXY(this Vector2 v, float y = 0.0f) => new(v.y, y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNXY(this Vector2 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYXN(this Vector2 v, float w = 0.0f) => new(v.y, v.y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYXN(this Vector2 v, float x = 0.0f, float w = 0.0f) => new(x, v.y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNXN(this Vector2 v, float y = 0.0f, float w = 0.0f) => new(v.y, y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNXN(this Vector2 v, float x = 0.0f, float y = 0.0f, float w = 0.0f) => new(x, y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYYX(this Vector2 v) => new(v.y, v.y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYYX(this Vector2 v, float x = 0.0f) => new(x, v.y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNYX(this Vector2 v, float y = 0.0f) => new(v.y, y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNYX(this Vector2 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYNX(this Vector2 v, float z = 0.0f) => new(v.y, v.y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYNX(this Vector2 v, float x = 0.0f, float z = 0.0f) => new(x, v.y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNNX(this Vector2 v, float y = 0.0f, float z = 0.0f) => new(v.y, y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNNX(this Vector2 v, float x = 0.0f, float y = 0.0f, float z = 0.0f) => new(x, y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYYY(this Vector2 v) => new(v.y, v.y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYYY(this Vector2 v, float x = 0.0f) => new(x, v.y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNYY(this Vector2 v, float y = 0.0f) => new(v.y, y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNYY(this Vector2 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYNY(this Vector2 v, float z = 0.0f) => new(v.y, v.y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYNY(this Vector2 v, float x = 0.0f, float z = 0.0f) => new(x, v.y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNNY(this Vector2 v, float y = 0.0f, float z = 0.0f) => new(v.y, y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNNY(this Vector2 v, float x = 0.0f, float y = 0.0f, float z = 0.0f) => new(x, y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYYN(this Vector2 v, float w = 0.0f) => new(v.y, v.y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYYN(this Vector2 v, float x = 0.0f, float w = 0.0f) => new(x, v.y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNYN(this Vector2 v, float y = 0.0f, float w = 0.0f) => new(v.y, y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNYN(this Vector2 v, float x = 0.0f, float y = 0.0f, float w = 0.0f) => new(x, y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYNN(this Vector2 v, float z = 0.0f, float w = 0.0f) => new(v.y, v.y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYNN(this Vector2 v, float x = 0.0f, float z = 0.0f, float w = 0.0f) => new(x, v.y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNNN(this Vector2 v, float y = 0.0f, float z = 0.0f, float w = 0.0f) => new(v.y, y, z, w);
    }
}
