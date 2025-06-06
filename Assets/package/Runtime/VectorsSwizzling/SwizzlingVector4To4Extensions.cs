using UnityEngine;

namespace AreYouFruits.VectorsSwizzling
{
    public static class SwizzlingVector4To4Extensions
    {
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXXX(this Vector4 v) => new(v.x, v.x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXXY(this Vector4 v) => new(v.x, v.x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXXZ(this Vector4 v) => new(v.x, v.x, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXXW(this Vector4 v) => new(v.x, v.x, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXXN(this Vector4 v, float w = 0.0f) => new(v.x, v.x, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXYX(this Vector4 v) => new(v.x, v.x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXZX(this Vector4 v) => new(v.x, v.x, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXWX(this Vector4 v) => new(v.x, v.x, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXNX(this Vector4 v, float z = 0.0f) => new(v.x, v.x, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXYY(this Vector4 v) => new(v.x, v.x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXZY(this Vector4 v) => new(v.x, v.x, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXWY(this Vector4 v) => new(v.x, v.x, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXNY(this Vector4 v, float z = 0.0f) => new(v.x, v.x, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXYZ(this Vector4 v) => new(v.x, v.x, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXZZ(this Vector4 v) => new(v.x, v.x, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXWZ(this Vector4 v) => new(v.x, v.x, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXNZ(this Vector4 v, float z = 0.0f) => new(v.x, v.x, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXYW(this Vector4 v) => new(v.x, v.x, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXZW(this Vector4 v) => new(v.x, v.x, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXWW(this Vector4 v) => new(v.x, v.x, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXNW(this Vector4 v, float z = 0.0f) => new(v.x, v.x, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXYN(this Vector4 v, float w = 0.0f) => new(v.x, v.x, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXZN(this Vector4 v, float w = 0.0f) => new(v.x, v.x, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXWN(this Vector4 v, float w = 0.0f) => new(v.x, v.x, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.x, v.x, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYXX(this Vector4 v) => new(v.x, v.y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZXX(this Vector4 v) => new(v.x, v.z, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWXX(this Vector4 v) => new(v.x, v.w, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNXX(this Vector4 v, float y = 0.0f) => new(v.x, y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYXY(this Vector4 v) => new(v.x, v.y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZXY(this Vector4 v) => new(v.x, v.z, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWXY(this Vector4 v) => new(v.x, v.w, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNXY(this Vector4 v, float y = 0.0f) => new(v.x, y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYXZ(this Vector4 v) => new(v.x, v.y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZXZ(this Vector4 v) => new(v.x, v.z, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWXZ(this Vector4 v) => new(v.x, v.w, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNXZ(this Vector4 v, float y = 0.0f) => new(v.x, y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYXW(this Vector4 v) => new(v.x, v.y, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZXW(this Vector4 v) => new(v.x, v.z, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWXW(this Vector4 v) => new(v.x, v.w, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNXW(this Vector4 v, float y = 0.0f) => new(v.x, y, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYXN(this Vector4 v, float w = 0.0f) => new(v.x, v.y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZXN(this Vector4 v, float w = 0.0f) => new(v.x, v.z, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWXN(this Vector4 v, float w = 0.0f) => new(v.x, v.w, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNXN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.x, y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYYX(this Vector4 v) => new(v.x, v.y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZYX(this Vector4 v) => new(v.x, v.z, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWYX(this Vector4 v) => new(v.x, v.w, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNYX(this Vector4 v, float y = 0.0f) => new(v.x, y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYZX(this Vector4 v) => new(v.x, v.y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZZX(this Vector4 v) => new(v.x, v.z, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWZX(this Vector4 v) => new(v.x, v.w, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNZX(this Vector4 v, float y = 0.0f) => new(v.x, y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYWX(this Vector4 v) => new(v.x, v.y, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZWX(this Vector4 v) => new(v.x, v.z, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWWX(this Vector4 v) => new(v.x, v.w, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNWX(this Vector4 v, float y = 0.0f) => new(v.x, y, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYNX(this Vector4 v, float z = 0.0f) => new(v.x, v.y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZNX(this Vector4 v, float z = 0.0f) => new(v.x, v.z, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWNX(this Vector4 v, float z = 0.0f) => new(v.x, v.w, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNNX(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.x, y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYYY(this Vector4 v) => new(v.x, v.y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZYY(this Vector4 v) => new(v.x, v.z, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWYY(this Vector4 v) => new(v.x, v.w, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNYY(this Vector4 v, float y = 0.0f) => new(v.x, y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYZY(this Vector4 v) => new(v.x, v.y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZZY(this Vector4 v) => new(v.x, v.z, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWZY(this Vector4 v) => new(v.x, v.w, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNZY(this Vector4 v, float y = 0.0f) => new(v.x, y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYWY(this Vector4 v) => new(v.x, v.y, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZWY(this Vector4 v) => new(v.x, v.z, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWWY(this Vector4 v) => new(v.x, v.w, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNWY(this Vector4 v, float y = 0.0f) => new(v.x, y, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYNY(this Vector4 v, float z = 0.0f) => new(v.x, v.y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZNY(this Vector4 v, float z = 0.0f) => new(v.x, v.z, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWNY(this Vector4 v, float z = 0.0f) => new(v.x, v.w, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNNY(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.x, y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYYZ(this Vector4 v) => new(v.x, v.y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZYZ(this Vector4 v) => new(v.x, v.z, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWYZ(this Vector4 v) => new(v.x, v.w, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNYZ(this Vector4 v, float y = 0.0f) => new(v.x, y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYZZ(this Vector4 v) => new(v.x, v.y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZZZ(this Vector4 v) => new(v.x, v.z, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWZZ(this Vector4 v) => new(v.x, v.w, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNZZ(this Vector4 v, float y = 0.0f) => new(v.x, y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYWZ(this Vector4 v) => new(v.x, v.y, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZWZ(this Vector4 v) => new(v.x, v.z, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWWZ(this Vector4 v) => new(v.x, v.w, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNWZ(this Vector4 v, float y = 0.0f) => new(v.x, y, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYNZ(this Vector4 v, float z = 0.0f) => new(v.x, v.y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZNZ(this Vector4 v, float z = 0.0f) => new(v.x, v.z, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWNZ(this Vector4 v, float z = 0.0f) => new(v.x, v.w, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNNZ(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.x, y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYYW(this Vector4 v) => new(v.x, v.y, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZYW(this Vector4 v) => new(v.x, v.z, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWYW(this Vector4 v) => new(v.x, v.w, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNYW(this Vector4 v, float y = 0.0f) => new(v.x, y, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYZW(this Vector4 v) => new(v.x, v.y, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZZW(this Vector4 v) => new(v.x, v.z, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWZW(this Vector4 v) => new(v.x, v.w, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNZW(this Vector4 v, float y = 0.0f) => new(v.x, y, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYWW(this Vector4 v) => new(v.x, v.y, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZWW(this Vector4 v) => new(v.x, v.z, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWWW(this Vector4 v) => new(v.x, v.w, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNWW(this Vector4 v, float y = 0.0f) => new(v.x, y, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYNW(this Vector4 v, float z = 0.0f) => new(v.x, v.y, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZNW(this Vector4 v, float z = 0.0f) => new(v.x, v.z, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWNW(this Vector4 v, float z = 0.0f) => new(v.x, v.w, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNNW(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.x, y, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYYN(this Vector4 v, float w = 0.0f) => new(v.x, v.y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZYN(this Vector4 v, float w = 0.0f) => new(v.x, v.z, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWYN(this Vector4 v, float w = 0.0f) => new(v.x, v.w, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNYN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.x, y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYZN(this Vector4 v, float w = 0.0f) => new(v.x, v.y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZZN(this Vector4 v, float w = 0.0f) => new(v.x, v.z, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWZN(this Vector4 v, float w = 0.0f) => new(v.x, v.w, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNZN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.x, y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYWN(this Vector4 v, float w = 0.0f) => new(v.x, v.y, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZWN(this Vector4 v, float w = 0.0f) => new(v.x, v.z, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWWN(this Vector4 v, float w = 0.0f) => new(v.x, v.w, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNWN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.x, y, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.x, v.y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.x, v.z, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XWNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.x, v.w, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNNN(this Vector4 v, float y = 0.0f, float z = 0.0f, float w = 0.0f) => new(v.x, y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXXX(this Vector4 v) => new(v.y, v.x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXXX(this Vector4 v) => new(v.z, v.x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXXX(this Vector4 v) => new(v.w, v.x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXXX(this Vector4 v, float x = 0.0f) => new(x, v.x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXXY(this Vector4 v) => new(v.y, v.x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXXY(this Vector4 v) => new(v.z, v.x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXXY(this Vector4 v) => new(v.w, v.x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXXY(this Vector4 v, float x = 0.0f) => new(x, v.x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXXZ(this Vector4 v) => new(v.y, v.x, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXXZ(this Vector4 v) => new(v.z, v.x, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXXZ(this Vector4 v) => new(v.w, v.x, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXXZ(this Vector4 v, float x = 0.0f) => new(x, v.x, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXXW(this Vector4 v) => new(v.y, v.x, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXXW(this Vector4 v) => new(v.z, v.x, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXXW(this Vector4 v) => new(v.w, v.x, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXXW(this Vector4 v, float x = 0.0f) => new(x, v.x, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXXN(this Vector4 v, float w = 0.0f) => new(v.y, v.x, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXXN(this Vector4 v, float w = 0.0f) => new(v.z, v.x, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXXN(this Vector4 v, float w = 0.0f) => new(v.w, v.x, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXXN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.x, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXYX(this Vector4 v) => new(v.y, v.x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXYX(this Vector4 v) => new(v.z, v.x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXYX(this Vector4 v) => new(v.w, v.x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXYX(this Vector4 v, float x = 0.0f) => new(x, v.x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXZX(this Vector4 v) => new(v.y, v.x, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXZX(this Vector4 v) => new(v.z, v.x, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXZX(this Vector4 v) => new(v.w, v.x, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXZX(this Vector4 v, float x = 0.0f) => new(x, v.x, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXWX(this Vector4 v) => new(v.y, v.x, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXWX(this Vector4 v) => new(v.z, v.x, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXWX(this Vector4 v) => new(v.w, v.x, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXWX(this Vector4 v, float x = 0.0f) => new(x, v.x, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXNX(this Vector4 v, float z = 0.0f) => new(v.y, v.x, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXNX(this Vector4 v, float z = 0.0f) => new(v.z, v.x, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXNX(this Vector4 v, float z = 0.0f) => new(v.w, v.x, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXNX(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.x, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXYY(this Vector4 v) => new(v.y, v.x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXYY(this Vector4 v) => new(v.z, v.x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXYY(this Vector4 v) => new(v.w, v.x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXYY(this Vector4 v, float x = 0.0f) => new(x, v.x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXZY(this Vector4 v) => new(v.y, v.x, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXZY(this Vector4 v) => new(v.z, v.x, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXZY(this Vector4 v) => new(v.w, v.x, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXZY(this Vector4 v, float x = 0.0f) => new(x, v.x, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXWY(this Vector4 v) => new(v.y, v.x, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXWY(this Vector4 v) => new(v.z, v.x, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXWY(this Vector4 v) => new(v.w, v.x, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXWY(this Vector4 v, float x = 0.0f) => new(x, v.x, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXNY(this Vector4 v, float z = 0.0f) => new(v.y, v.x, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXNY(this Vector4 v, float z = 0.0f) => new(v.z, v.x, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXNY(this Vector4 v, float z = 0.0f) => new(v.w, v.x, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXNY(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.x, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXYZ(this Vector4 v) => new(v.y, v.x, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXYZ(this Vector4 v) => new(v.z, v.x, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXYZ(this Vector4 v) => new(v.w, v.x, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXYZ(this Vector4 v, float x = 0.0f) => new(x, v.x, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXZZ(this Vector4 v) => new(v.y, v.x, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXZZ(this Vector4 v) => new(v.z, v.x, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXZZ(this Vector4 v) => new(v.w, v.x, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXZZ(this Vector4 v, float x = 0.0f) => new(x, v.x, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXWZ(this Vector4 v) => new(v.y, v.x, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXWZ(this Vector4 v) => new(v.z, v.x, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXWZ(this Vector4 v) => new(v.w, v.x, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXWZ(this Vector4 v, float x = 0.0f) => new(x, v.x, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXNZ(this Vector4 v, float z = 0.0f) => new(v.y, v.x, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXNZ(this Vector4 v, float z = 0.0f) => new(v.z, v.x, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXNZ(this Vector4 v, float z = 0.0f) => new(v.w, v.x, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXNZ(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.x, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXYW(this Vector4 v) => new(v.y, v.x, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXYW(this Vector4 v) => new(v.z, v.x, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXYW(this Vector4 v) => new(v.w, v.x, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXYW(this Vector4 v, float x = 0.0f) => new(x, v.x, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXZW(this Vector4 v) => new(v.y, v.x, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXZW(this Vector4 v) => new(v.z, v.x, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXZW(this Vector4 v) => new(v.w, v.x, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXZW(this Vector4 v, float x = 0.0f) => new(x, v.x, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXWW(this Vector4 v) => new(v.y, v.x, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXWW(this Vector4 v) => new(v.z, v.x, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXWW(this Vector4 v) => new(v.w, v.x, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXWW(this Vector4 v, float x = 0.0f) => new(x, v.x, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXNW(this Vector4 v, float z = 0.0f) => new(v.y, v.x, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXNW(this Vector4 v, float z = 0.0f) => new(v.z, v.x, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXNW(this Vector4 v, float z = 0.0f) => new(v.w, v.x, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXNW(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.x, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXYN(this Vector4 v, float w = 0.0f) => new(v.y, v.x, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXYN(this Vector4 v, float w = 0.0f) => new(v.z, v.x, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXYN(this Vector4 v, float w = 0.0f) => new(v.w, v.x, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXYN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.x, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXZN(this Vector4 v, float w = 0.0f) => new(v.y, v.x, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXZN(this Vector4 v, float w = 0.0f) => new(v.z, v.x, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXZN(this Vector4 v, float w = 0.0f) => new(v.w, v.x, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXZN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.x, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXWN(this Vector4 v, float w = 0.0f) => new(v.y, v.x, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXWN(this Vector4 v, float w = 0.0f) => new(v.z, v.x, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXWN(this Vector4 v, float w = 0.0f) => new(v.w, v.x, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXWN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.x, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.y, v.x, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.z, v.x, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WXNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.w, v.x, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXNN(this Vector4 v, float x = 0.0f, float z = 0.0f, float w = 0.0f) => new(x, v.x, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYXX(this Vector4 v) => new(v.y, v.y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYXX(this Vector4 v) => new(v.z, v.y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYXX(this Vector4 v) => new(v.w, v.y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYXX(this Vector4 v, float x = 0.0f) => new(x, v.y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZXX(this Vector4 v) => new(v.y, v.z, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZXX(this Vector4 v) => new(v.z, v.z, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZXX(this Vector4 v) => new(v.w, v.z, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZXX(this Vector4 v, float x = 0.0f) => new(x, v.z, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWXX(this Vector4 v) => new(v.y, v.w, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWXX(this Vector4 v) => new(v.z, v.w, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWXX(this Vector4 v) => new(v.w, v.w, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWXX(this Vector4 v, float x = 0.0f) => new(x, v.w, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNXX(this Vector4 v, float y = 0.0f) => new(v.y, y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNXX(this Vector4 v, float y = 0.0f) => new(v.z, y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNXX(this Vector4 v, float y = 0.0f) => new(v.w, y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNXX(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYXY(this Vector4 v) => new(v.y, v.y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYXY(this Vector4 v) => new(v.z, v.y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYXY(this Vector4 v) => new(v.w, v.y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYXY(this Vector4 v, float x = 0.0f) => new(x, v.y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZXY(this Vector4 v) => new(v.y, v.z, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZXY(this Vector4 v) => new(v.z, v.z, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZXY(this Vector4 v) => new(v.w, v.z, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZXY(this Vector4 v, float x = 0.0f) => new(x, v.z, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWXY(this Vector4 v) => new(v.y, v.w, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWXY(this Vector4 v) => new(v.z, v.w, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWXY(this Vector4 v) => new(v.w, v.w, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWXY(this Vector4 v, float x = 0.0f) => new(x, v.w, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNXY(this Vector4 v, float y = 0.0f) => new(v.y, y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNXY(this Vector4 v, float y = 0.0f) => new(v.z, y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNXY(this Vector4 v, float y = 0.0f) => new(v.w, y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNXY(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYXZ(this Vector4 v) => new(v.y, v.y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYXZ(this Vector4 v) => new(v.z, v.y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYXZ(this Vector4 v) => new(v.w, v.y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYXZ(this Vector4 v, float x = 0.0f) => new(x, v.y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZXZ(this Vector4 v) => new(v.y, v.z, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZXZ(this Vector4 v) => new(v.z, v.z, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZXZ(this Vector4 v) => new(v.w, v.z, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZXZ(this Vector4 v, float x = 0.0f) => new(x, v.z, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWXZ(this Vector4 v) => new(v.y, v.w, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWXZ(this Vector4 v) => new(v.z, v.w, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWXZ(this Vector4 v) => new(v.w, v.w, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWXZ(this Vector4 v, float x = 0.0f) => new(x, v.w, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNXZ(this Vector4 v, float y = 0.0f) => new(v.y, y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNXZ(this Vector4 v, float y = 0.0f) => new(v.z, y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNXZ(this Vector4 v, float y = 0.0f) => new(v.w, y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNXZ(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYXW(this Vector4 v) => new(v.y, v.y, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYXW(this Vector4 v) => new(v.z, v.y, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYXW(this Vector4 v) => new(v.w, v.y, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYXW(this Vector4 v, float x = 0.0f) => new(x, v.y, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZXW(this Vector4 v) => new(v.y, v.z, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZXW(this Vector4 v) => new(v.z, v.z, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZXW(this Vector4 v) => new(v.w, v.z, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZXW(this Vector4 v, float x = 0.0f) => new(x, v.z, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWXW(this Vector4 v) => new(v.y, v.w, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWXW(this Vector4 v) => new(v.z, v.w, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWXW(this Vector4 v) => new(v.w, v.w, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWXW(this Vector4 v, float x = 0.0f) => new(x, v.w, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNXW(this Vector4 v, float y = 0.0f) => new(v.y, y, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNXW(this Vector4 v, float y = 0.0f) => new(v.z, y, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNXW(this Vector4 v, float y = 0.0f) => new(v.w, y, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNXW(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYXN(this Vector4 v, float w = 0.0f) => new(v.y, v.y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYXN(this Vector4 v, float w = 0.0f) => new(v.z, v.y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYXN(this Vector4 v, float w = 0.0f) => new(v.w, v.y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYXN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZXN(this Vector4 v, float w = 0.0f) => new(v.y, v.z, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZXN(this Vector4 v, float w = 0.0f) => new(v.z, v.z, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZXN(this Vector4 v, float w = 0.0f) => new(v.w, v.z, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZXN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.z, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWXN(this Vector4 v, float w = 0.0f) => new(v.y, v.w, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWXN(this Vector4 v, float w = 0.0f) => new(v.z, v.w, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWXN(this Vector4 v, float w = 0.0f) => new(v.w, v.w, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWXN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.w, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNXN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.y, y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNXN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.z, y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNXN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.w, y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNXN(this Vector4 v, float x = 0.0f, float y = 0.0f, float w = 0.0f) => new(x, y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYYX(this Vector4 v) => new(v.y, v.y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYYX(this Vector4 v) => new(v.z, v.y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYYX(this Vector4 v) => new(v.w, v.y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYYX(this Vector4 v, float x = 0.0f) => new(x, v.y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZYX(this Vector4 v) => new(v.y, v.z, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZYX(this Vector4 v) => new(v.z, v.z, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZYX(this Vector4 v) => new(v.w, v.z, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZYX(this Vector4 v, float x = 0.0f) => new(x, v.z, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWYX(this Vector4 v) => new(v.y, v.w, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWYX(this Vector4 v) => new(v.z, v.w, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWYX(this Vector4 v) => new(v.w, v.w, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWYX(this Vector4 v, float x = 0.0f) => new(x, v.w, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNYX(this Vector4 v, float y = 0.0f) => new(v.y, y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNYX(this Vector4 v, float y = 0.0f) => new(v.z, y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNYX(this Vector4 v, float y = 0.0f) => new(v.w, y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNYX(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYZX(this Vector4 v) => new(v.y, v.y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYZX(this Vector4 v) => new(v.z, v.y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYZX(this Vector4 v) => new(v.w, v.y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYZX(this Vector4 v, float x = 0.0f) => new(x, v.y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZZX(this Vector4 v) => new(v.y, v.z, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZZX(this Vector4 v) => new(v.z, v.z, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZZX(this Vector4 v) => new(v.w, v.z, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZZX(this Vector4 v, float x = 0.0f) => new(x, v.z, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWZX(this Vector4 v) => new(v.y, v.w, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWZX(this Vector4 v) => new(v.z, v.w, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWZX(this Vector4 v) => new(v.w, v.w, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWZX(this Vector4 v, float x = 0.0f) => new(x, v.w, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNZX(this Vector4 v, float y = 0.0f) => new(v.y, y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNZX(this Vector4 v, float y = 0.0f) => new(v.z, y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNZX(this Vector4 v, float y = 0.0f) => new(v.w, y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNZX(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYWX(this Vector4 v) => new(v.y, v.y, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYWX(this Vector4 v) => new(v.z, v.y, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYWX(this Vector4 v) => new(v.w, v.y, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYWX(this Vector4 v, float x = 0.0f) => new(x, v.y, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZWX(this Vector4 v) => new(v.y, v.z, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZWX(this Vector4 v) => new(v.z, v.z, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZWX(this Vector4 v) => new(v.w, v.z, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZWX(this Vector4 v, float x = 0.0f) => new(x, v.z, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWWX(this Vector4 v) => new(v.y, v.w, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWWX(this Vector4 v) => new(v.z, v.w, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWWX(this Vector4 v) => new(v.w, v.w, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWWX(this Vector4 v, float x = 0.0f) => new(x, v.w, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNWX(this Vector4 v, float y = 0.0f) => new(v.y, y, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNWX(this Vector4 v, float y = 0.0f) => new(v.z, y, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNWX(this Vector4 v, float y = 0.0f) => new(v.w, y, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNWX(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYNX(this Vector4 v, float z = 0.0f) => new(v.y, v.y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYNX(this Vector4 v, float z = 0.0f) => new(v.z, v.y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYNX(this Vector4 v, float z = 0.0f) => new(v.w, v.y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYNX(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZNX(this Vector4 v, float z = 0.0f) => new(v.y, v.z, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZNX(this Vector4 v, float z = 0.0f) => new(v.z, v.z, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZNX(this Vector4 v, float z = 0.0f) => new(v.w, v.z, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZNX(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.z, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWNX(this Vector4 v, float z = 0.0f) => new(v.y, v.w, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWNX(this Vector4 v, float z = 0.0f) => new(v.z, v.w, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWNX(this Vector4 v, float z = 0.0f) => new(v.w, v.w, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWNX(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.w, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNNX(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.y, y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNNX(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.z, y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNNX(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.w, y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNNX(this Vector4 v, float x = 0.0f, float y = 0.0f, float z = 0.0f) => new(x, y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYYY(this Vector4 v) => new(v.y, v.y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYYY(this Vector4 v) => new(v.z, v.y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYYY(this Vector4 v) => new(v.w, v.y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYYY(this Vector4 v, float x = 0.0f) => new(x, v.y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZYY(this Vector4 v) => new(v.y, v.z, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZYY(this Vector4 v) => new(v.z, v.z, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZYY(this Vector4 v) => new(v.w, v.z, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZYY(this Vector4 v, float x = 0.0f) => new(x, v.z, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWYY(this Vector4 v) => new(v.y, v.w, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWYY(this Vector4 v) => new(v.z, v.w, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWYY(this Vector4 v) => new(v.w, v.w, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWYY(this Vector4 v, float x = 0.0f) => new(x, v.w, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNYY(this Vector4 v, float y = 0.0f) => new(v.y, y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNYY(this Vector4 v, float y = 0.0f) => new(v.z, y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNYY(this Vector4 v, float y = 0.0f) => new(v.w, y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNYY(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYZY(this Vector4 v) => new(v.y, v.y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYZY(this Vector4 v) => new(v.z, v.y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYZY(this Vector4 v) => new(v.w, v.y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYZY(this Vector4 v, float x = 0.0f) => new(x, v.y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZZY(this Vector4 v) => new(v.y, v.z, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZZY(this Vector4 v) => new(v.z, v.z, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZZY(this Vector4 v) => new(v.w, v.z, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZZY(this Vector4 v, float x = 0.0f) => new(x, v.z, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWZY(this Vector4 v) => new(v.y, v.w, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWZY(this Vector4 v) => new(v.z, v.w, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWZY(this Vector4 v) => new(v.w, v.w, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWZY(this Vector4 v, float x = 0.0f) => new(x, v.w, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNZY(this Vector4 v, float y = 0.0f) => new(v.y, y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNZY(this Vector4 v, float y = 0.0f) => new(v.z, y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNZY(this Vector4 v, float y = 0.0f) => new(v.w, y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNZY(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYWY(this Vector4 v) => new(v.y, v.y, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYWY(this Vector4 v) => new(v.z, v.y, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYWY(this Vector4 v) => new(v.w, v.y, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYWY(this Vector4 v, float x = 0.0f) => new(x, v.y, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZWY(this Vector4 v) => new(v.y, v.z, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZWY(this Vector4 v) => new(v.z, v.z, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZWY(this Vector4 v) => new(v.w, v.z, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZWY(this Vector4 v, float x = 0.0f) => new(x, v.z, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWWY(this Vector4 v) => new(v.y, v.w, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWWY(this Vector4 v) => new(v.z, v.w, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWWY(this Vector4 v) => new(v.w, v.w, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWWY(this Vector4 v, float x = 0.0f) => new(x, v.w, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNWY(this Vector4 v, float y = 0.0f) => new(v.y, y, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNWY(this Vector4 v, float y = 0.0f) => new(v.z, y, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNWY(this Vector4 v, float y = 0.0f) => new(v.w, y, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNWY(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYNY(this Vector4 v, float z = 0.0f) => new(v.y, v.y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYNY(this Vector4 v, float z = 0.0f) => new(v.z, v.y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYNY(this Vector4 v, float z = 0.0f) => new(v.w, v.y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYNY(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZNY(this Vector4 v, float z = 0.0f) => new(v.y, v.z, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZNY(this Vector4 v, float z = 0.0f) => new(v.z, v.z, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZNY(this Vector4 v, float z = 0.0f) => new(v.w, v.z, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZNY(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.z, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWNY(this Vector4 v, float z = 0.0f) => new(v.y, v.w, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWNY(this Vector4 v, float z = 0.0f) => new(v.z, v.w, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWNY(this Vector4 v, float z = 0.0f) => new(v.w, v.w, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWNY(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.w, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNNY(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.y, y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNNY(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.z, y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNNY(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.w, y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNNY(this Vector4 v, float x = 0.0f, float y = 0.0f, float z = 0.0f) => new(x, y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYYZ(this Vector4 v) => new(v.y, v.y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYYZ(this Vector4 v) => new(v.z, v.y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYYZ(this Vector4 v) => new(v.w, v.y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYYZ(this Vector4 v, float x = 0.0f) => new(x, v.y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZYZ(this Vector4 v) => new(v.y, v.z, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZYZ(this Vector4 v) => new(v.z, v.z, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZYZ(this Vector4 v) => new(v.w, v.z, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZYZ(this Vector4 v, float x = 0.0f) => new(x, v.z, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWYZ(this Vector4 v) => new(v.y, v.w, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWYZ(this Vector4 v) => new(v.z, v.w, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWYZ(this Vector4 v) => new(v.w, v.w, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWYZ(this Vector4 v, float x = 0.0f) => new(x, v.w, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNYZ(this Vector4 v, float y = 0.0f) => new(v.y, y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNYZ(this Vector4 v, float y = 0.0f) => new(v.z, y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNYZ(this Vector4 v, float y = 0.0f) => new(v.w, y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNYZ(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYZZ(this Vector4 v) => new(v.y, v.y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYZZ(this Vector4 v) => new(v.z, v.y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYZZ(this Vector4 v) => new(v.w, v.y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYZZ(this Vector4 v, float x = 0.0f) => new(x, v.y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZZZ(this Vector4 v) => new(v.y, v.z, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZZZ(this Vector4 v) => new(v.z, v.z, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZZZ(this Vector4 v) => new(v.w, v.z, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZZZ(this Vector4 v, float x = 0.0f) => new(x, v.z, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWZZ(this Vector4 v) => new(v.y, v.w, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWZZ(this Vector4 v) => new(v.z, v.w, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWZZ(this Vector4 v) => new(v.w, v.w, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWZZ(this Vector4 v, float x = 0.0f) => new(x, v.w, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNZZ(this Vector4 v, float y = 0.0f) => new(v.y, y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNZZ(this Vector4 v, float y = 0.0f) => new(v.z, y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNZZ(this Vector4 v, float y = 0.0f) => new(v.w, y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNZZ(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYWZ(this Vector4 v) => new(v.y, v.y, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYWZ(this Vector4 v) => new(v.z, v.y, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYWZ(this Vector4 v) => new(v.w, v.y, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYWZ(this Vector4 v, float x = 0.0f) => new(x, v.y, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZWZ(this Vector4 v) => new(v.y, v.z, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZWZ(this Vector4 v) => new(v.z, v.z, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZWZ(this Vector4 v) => new(v.w, v.z, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZWZ(this Vector4 v, float x = 0.0f) => new(x, v.z, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWWZ(this Vector4 v) => new(v.y, v.w, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWWZ(this Vector4 v) => new(v.z, v.w, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWWZ(this Vector4 v) => new(v.w, v.w, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWWZ(this Vector4 v, float x = 0.0f) => new(x, v.w, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNWZ(this Vector4 v, float y = 0.0f) => new(v.y, y, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNWZ(this Vector4 v, float y = 0.0f) => new(v.z, y, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNWZ(this Vector4 v, float y = 0.0f) => new(v.w, y, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNWZ(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYNZ(this Vector4 v, float z = 0.0f) => new(v.y, v.y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYNZ(this Vector4 v, float z = 0.0f) => new(v.z, v.y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYNZ(this Vector4 v, float z = 0.0f) => new(v.w, v.y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYNZ(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZNZ(this Vector4 v, float z = 0.0f) => new(v.y, v.z, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZNZ(this Vector4 v, float z = 0.0f) => new(v.z, v.z, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZNZ(this Vector4 v, float z = 0.0f) => new(v.w, v.z, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZNZ(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.z, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWNZ(this Vector4 v, float z = 0.0f) => new(v.y, v.w, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWNZ(this Vector4 v, float z = 0.0f) => new(v.z, v.w, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWNZ(this Vector4 v, float z = 0.0f) => new(v.w, v.w, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWNZ(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.w, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNNZ(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.y, y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNNZ(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.z, y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNNZ(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.w, y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNNZ(this Vector4 v, float x = 0.0f, float y = 0.0f, float z = 0.0f) => new(x, y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYYW(this Vector4 v) => new(v.y, v.y, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYYW(this Vector4 v) => new(v.z, v.y, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYYW(this Vector4 v) => new(v.w, v.y, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYYW(this Vector4 v, float x = 0.0f) => new(x, v.y, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZYW(this Vector4 v) => new(v.y, v.z, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZYW(this Vector4 v) => new(v.z, v.z, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZYW(this Vector4 v) => new(v.w, v.z, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZYW(this Vector4 v, float x = 0.0f) => new(x, v.z, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWYW(this Vector4 v) => new(v.y, v.w, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWYW(this Vector4 v) => new(v.z, v.w, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWYW(this Vector4 v) => new(v.w, v.w, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWYW(this Vector4 v, float x = 0.0f) => new(x, v.w, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNYW(this Vector4 v, float y = 0.0f) => new(v.y, y, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNYW(this Vector4 v, float y = 0.0f) => new(v.z, y, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNYW(this Vector4 v, float y = 0.0f) => new(v.w, y, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNYW(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYZW(this Vector4 v) => new(v.y, v.y, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYZW(this Vector4 v) => new(v.z, v.y, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYZW(this Vector4 v) => new(v.w, v.y, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYZW(this Vector4 v, float x = 0.0f) => new(x, v.y, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZZW(this Vector4 v) => new(v.y, v.z, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZZW(this Vector4 v) => new(v.z, v.z, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZZW(this Vector4 v) => new(v.w, v.z, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZZW(this Vector4 v, float x = 0.0f) => new(x, v.z, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWZW(this Vector4 v) => new(v.y, v.w, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWZW(this Vector4 v) => new(v.z, v.w, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWZW(this Vector4 v) => new(v.w, v.w, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWZW(this Vector4 v, float x = 0.0f) => new(x, v.w, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNZW(this Vector4 v, float y = 0.0f) => new(v.y, y, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNZW(this Vector4 v, float y = 0.0f) => new(v.z, y, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNZW(this Vector4 v, float y = 0.0f) => new(v.w, y, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNZW(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYWW(this Vector4 v) => new(v.y, v.y, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYWW(this Vector4 v) => new(v.z, v.y, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYWW(this Vector4 v) => new(v.w, v.y, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYWW(this Vector4 v, float x = 0.0f) => new(x, v.y, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZWW(this Vector4 v) => new(v.y, v.z, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZWW(this Vector4 v) => new(v.z, v.z, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZWW(this Vector4 v) => new(v.w, v.z, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZWW(this Vector4 v, float x = 0.0f) => new(x, v.z, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWWW(this Vector4 v) => new(v.y, v.w, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWWW(this Vector4 v) => new(v.z, v.w, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWWW(this Vector4 v) => new(v.w, v.w, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWWW(this Vector4 v, float x = 0.0f) => new(x, v.w, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNWW(this Vector4 v, float y = 0.0f) => new(v.y, y, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNWW(this Vector4 v, float y = 0.0f) => new(v.z, y, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNWW(this Vector4 v, float y = 0.0f) => new(v.w, y, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNWW(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYNW(this Vector4 v, float z = 0.0f) => new(v.y, v.y, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYNW(this Vector4 v, float z = 0.0f) => new(v.z, v.y, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYNW(this Vector4 v, float z = 0.0f) => new(v.w, v.y, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYNW(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.y, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZNW(this Vector4 v, float z = 0.0f) => new(v.y, v.z, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZNW(this Vector4 v, float z = 0.0f) => new(v.z, v.z, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZNW(this Vector4 v, float z = 0.0f) => new(v.w, v.z, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZNW(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.z, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWNW(this Vector4 v, float z = 0.0f) => new(v.y, v.w, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWNW(this Vector4 v, float z = 0.0f) => new(v.z, v.w, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWNW(this Vector4 v, float z = 0.0f) => new(v.w, v.w, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWNW(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.w, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNNW(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.y, y, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNNW(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.z, y, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNNW(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.w, y, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNNW(this Vector4 v, float x = 0.0f, float y = 0.0f, float z = 0.0f) => new(x, y, z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYYN(this Vector4 v, float w = 0.0f) => new(v.y, v.y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYYN(this Vector4 v, float w = 0.0f) => new(v.z, v.y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYYN(this Vector4 v, float w = 0.0f) => new(v.w, v.y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYYN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZYN(this Vector4 v, float w = 0.0f) => new(v.y, v.z, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZYN(this Vector4 v, float w = 0.0f) => new(v.z, v.z, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZYN(this Vector4 v, float w = 0.0f) => new(v.w, v.z, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZYN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.z, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWYN(this Vector4 v, float w = 0.0f) => new(v.y, v.w, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWYN(this Vector4 v, float w = 0.0f) => new(v.z, v.w, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWYN(this Vector4 v, float w = 0.0f) => new(v.w, v.w, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWYN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.w, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNYN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.y, y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNYN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.z, y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNYN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.w, y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNYN(this Vector4 v, float x = 0.0f, float y = 0.0f, float w = 0.0f) => new(x, y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYZN(this Vector4 v, float w = 0.0f) => new(v.y, v.y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYZN(this Vector4 v, float w = 0.0f) => new(v.z, v.y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYZN(this Vector4 v, float w = 0.0f) => new(v.w, v.y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYZN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZZN(this Vector4 v, float w = 0.0f) => new(v.y, v.z, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZZN(this Vector4 v, float w = 0.0f) => new(v.z, v.z, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZZN(this Vector4 v, float w = 0.0f) => new(v.w, v.z, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZZN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.z, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWZN(this Vector4 v, float w = 0.0f) => new(v.y, v.w, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWZN(this Vector4 v, float w = 0.0f) => new(v.z, v.w, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWZN(this Vector4 v, float w = 0.0f) => new(v.w, v.w, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWZN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.w, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNZN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.y, y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNZN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.z, y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNZN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.w, y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNZN(this Vector4 v, float x = 0.0f, float y = 0.0f, float w = 0.0f) => new(x, y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYWN(this Vector4 v, float w = 0.0f) => new(v.y, v.y, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYWN(this Vector4 v, float w = 0.0f) => new(v.z, v.y, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYWN(this Vector4 v, float w = 0.0f) => new(v.w, v.y, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYWN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.y, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZWN(this Vector4 v, float w = 0.0f) => new(v.y, v.z, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZWN(this Vector4 v, float w = 0.0f) => new(v.z, v.z, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZWN(this Vector4 v, float w = 0.0f) => new(v.w, v.z, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZWN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.z, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWWN(this Vector4 v, float w = 0.0f) => new(v.y, v.w, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWWN(this Vector4 v, float w = 0.0f) => new(v.z, v.w, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWWN(this Vector4 v, float w = 0.0f) => new(v.w, v.w, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWWN(this Vector4 v, float x = 0.0f, float w = 0.0f) => new(x, v.w, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNWN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.y, y, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNWN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.z, y, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNWN(this Vector4 v, float y = 0.0f, float w = 0.0f) => new(v.w, y, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNWN(this Vector4 v, float x = 0.0f, float y = 0.0f, float w = 0.0f) => new(x, y, v.w, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.y, v.y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.z, v.y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WYNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.w, v.y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYNN(this Vector4 v, float x = 0.0f, float z = 0.0f, float w = 0.0f) => new(x, v.y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.y, v.z, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.z, v.z, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WZNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.w, v.z, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZNN(this Vector4 v, float x = 0.0f, float z = 0.0f, float w = 0.0f) => new(x, v.z, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YWNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.y, v.w, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZWNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.z, v.w, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WWNN(this Vector4 v, float z = 0.0f, float w = 0.0f) => new(v.w, v.w, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NWNN(this Vector4 v, float x = 0.0f, float z = 0.0f, float w = 0.0f) => new(x, v.w, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNNN(this Vector4 v, float y = 0.0f, float z = 0.0f, float w = 0.0f) => new(v.y, y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNNN(this Vector4 v, float y = 0.0f, float z = 0.0f, float w = 0.0f) => new(v.z, y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 WNNN(this Vector4 v, float y = 0.0f, float z = 0.0f, float w = 0.0f) => new(v.w, y, z, w);
    }
}
