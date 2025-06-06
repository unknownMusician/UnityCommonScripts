using UnityEngine;

namespace AreYouFruits.VectorsSwizzling
{
    public static class SwizzlingVector3To4Extensions
    {
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXXX(this Vector3 v) => new(v.x, v.x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXXY(this Vector3 v) => new(v.x, v.x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXXZ(this Vector3 v) => new(v.x, v.x, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXXN(this Vector3 v, float w = 0.0f) => new(v.x, v.x, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXYX(this Vector3 v) => new(v.x, v.x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXZX(this Vector3 v) => new(v.x, v.x, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXNX(this Vector3 v, float z = 0.0f) => new(v.x, v.x, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXYY(this Vector3 v) => new(v.x, v.x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXZY(this Vector3 v) => new(v.x, v.x, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXNY(this Vector3 v, float z = 0.0f) => new(v.x, v.x, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXYZ(this Vector3 v) => new(v.x, v.x, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXZZ(this Vector3 v) => new(v.x, v.x, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXNZ(this Vector3 v, float z = 0.0f) => new(v.x, v.x, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXYN(this Vector3 v, float w = 0.0f) => new(v.x, v.x, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXZN(this Vector3 v, float w = 0.0f) => new(v.x, v.x, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XXNN(this Vector3 v, float z = 0.0f, float w = 0.0f) => new(v.x, v.x, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYXX(this Vector3 v) => new(v.x, v.y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZXX(this Vector3 v) => new(v.x, v.z, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNXX(this Vector3 v, float y = 0.0f) => new(v.x, y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYXY(this Vector3 v) => new(v.x, v.y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZXY(this Vector3 v) => new(v.x, v.z, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNXY(this Vector3 v, float y = 0.0f) => new(v.x, y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYXZ(this Vector3 v) => new(v.x, v.y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZXZ(this Vector3 v) => new(v.x, v.z, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNXZ(this Vector3 v, float y = 0.0f) => new(v.x, y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYXN(this Vector3 v, float w = 0.0f) => new(v.x, v.y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZXN(this Vector3 v, float w = 0.0f) => new(v.x, v.z, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNXN(this Vector3 v, float y = 0.0f, float w = 0.0f) => new(v.x, y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYYX(this Vector3 v) => new(v.x, v.y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZYX(this Vector3 v) => new(v.x, v.z, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNYX(this Vector3 v, float y = 0.0f) => new(v.x, y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYZX(this Vector3 v) => new(v.x, v.y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZZX(this Vector3 v) => new(v.x, v.z, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNZX(this Vector3 v, float y = 0.0f) => new(v.x, y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYNX(this Vector3 v, float z = 0.0f) => new(v.x, v.y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZNX(this Vector3 v, float z = 0.0f) => new(v.x, v.z, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNNX(this Vector3 v, float y = 0.0f, float z = 0.0f) => new(v.x, y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYYY(this Vector3 v) => new(v.x, v.y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZYY(this Vector3 v) => new(v.x, v.z, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNYY(this Vector3 v, float y = 0.0f) => new(v.x, y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYZY(this Vector3 v) => new(v.x, v.y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZZY(this Vector3 v) => new(v.x, v.z, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNZY(this Vector3 v, float y = 0.0f) => new(v.x, y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYNY(this Vector3 v, float z = 0.0f) => new(v.x, v.y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZNY(this Vector3 v, float z = 0.0f) => new(v.x, v.z, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNNY(this Vector3 v, float y = 0.0f, float z = 0.0f) => new(v.x, y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYYZ(this Vector3 v) => new(v.x, v.y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZYZ(this Vector3 v) => new(v.x, v.z, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNYZ(this Vector3 v, float y = 0.0f) => new(v.x, y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYZZ(this Vector3 v) => new(v.x, v.y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZZZ(this Vector3 v) => new(v.x, v.z, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNZZ(this Vector3 v, float y = 0.0f) => new(v.x, y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYNZ(this Vector3 v, float z = 0.0f) => new(v.x, v.y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZNZ(this Vector3 v, float z = 0.0f) => new(v.x, v.z, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNNZ(this Vector3 v, float y = 0.0f, float z = 0.0f) => new(v.x, y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYYN(this Vector3 v, float w = 0.0f) => new(v.x, v.y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZYN(this Vector3 v, float w = 0.0f) => new(v.x, v.z, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNYN(this Vector3 v, float y = 0.0f, float w = 0.0f) => new(v.x, y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYZN(this Vector3 v, float w = 0.0f) => new(v.x, v.y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZZN(this Vector3 v, float w = 0.0f) => new(v.x, v.z, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNZN(this Vector3 v, float y = 0.0f, float w = 0.0f) => new(v.x, y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XYNN(this Vector3 v, float z = 0.0f, float w = 0.0f) => new(v.x, v.y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XZNN(this Vector3 v, float z = 0.0f, float w = 0.0f) => new(v.x, v.z, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 XNNN(this Vector3 v, float y = 0.0f, float z = 0.0f, float w = 0.0f) => new(v.x, y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXXX(this Vector3 v) => new(v.y, v.x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXXX(this Vector3 v) => new(v.z, v.x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXXX(this Vector3 v, float x = 0.0f) => new(x, v.x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXXY(this Vector3 v) => new(v.y, v.x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXXY(this Vector3 v) => new(v.z, v.x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXXY(this Vector3 v, float x = 0.0f) => new(x, v.x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXXZ(this Vector3 v) => new(v.y, v.x, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXXZ(this Vector3 v) => new(v.z, v.x, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXXZ(this Vector3 v, float x = 0.0f) => new(x, v.x, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXXN(this Vector3 v, float w = 0.0f) => new(v.y, v.x, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXXN(this Vector3 v, float w = 0.0f) => new(v.z, v.x, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXXN(this Vector3 v, float x = 0.0f, float w = 0.0f) => new(x, v.x, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXYX(this Vector3 v) => new(v.y, v.x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXYX(this Vector3 v) => new(v.z, v.x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXYX(this Vector3 v, float x = 0.0f) => new(x, v.x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXZX(this Vector3 v) => new(v.y, v.x, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXZX(this Vector3 v) => new(v.z, v.x, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXZX(this Vector3 v, float x = 0.0f) => new(x, v.x, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXNX(this Vector3 v, float z = 0.0f) => new(v.y, v.x, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXNX(this Vector3 v, float z = 0.0f) => new(v.z, v.x, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXNX(this Vector3 v, float x = 0.0f, float z = 0.0f) => new(x, v.x, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXYY(this Vector3 v) => new(v.y, v.x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXYY(this Vector3 v) => new(v.z, v.x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXYY(this Vector3 v, float x = 0.0f) => new(x, v.x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXZY(this Vector3 v) => new(v.y, v.x, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXZY(this Vector3 v) => new(v.z, v.x, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXZY(this Vector3 v, float x = 0.0f) => new(x, v.x, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXNY(this Vector3 v, float z = 0.0f) => new(v.y, v.x, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXNY(this Vector3 v, float z = 0.0f) => new(v.z, v.x, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXNY(this Vector3 v, float x = 0.0f, float z = 0.0f) => new(x, v.x, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXYZ(this Vector3 v) => new(v.y, v.x, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXYZ(this Vector3 v) => new(v.z, v.x, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXYZ(this Vector3 v, float x = 0.0f) => new(x, v.x, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXZZ(this Vector3 v) => new(v.y, v.x, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXZZ(this Vector3 v) => new(v.z, v.x, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXZZ(this Vector3 v, float x = 0.0f) => new(x, v.x, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXNZ(this Vector3 v, float z = 0.0f) => new(v.y, v.x, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXNZ(this Vector3 v, float z = 0.0f) => new(v.z, v.x, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXNZ(this Vector3 v, float x = 0.0f, float z = 0.0f) => new(x, v.x, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXYN(this Vector3 v, float w = 0.0f) => new(v.y, v.x, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXYN(this Vector3 v, float w = 0.0f) => new(v.z, v.x, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXYN(this Vector3 v, float x = 0.0f, float w = 0.0f) => new(x, v.x, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXZN(this Vector3 v, float w = 0.0f) => new(v.y, v.x, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXZN(this Vector3 v, float w = 0.0f) => new(v.z, v.x, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXZN(this Vector3 v, float x = 0.0f, float w = 0.0f) => new(x, v.x, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YXNN(this Vector3 v, float z = 0.0f, float w = 0.0f) => new(v.y, v.x, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZXNN(this Vector3 v, float z = 0.0f, float w = 0.0f) => new(v.z, v.x, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NXNN(this Vector3 v, float x = 0.0f, float z = 0.0f, float w = 0.0f) => new(x, v.x, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYXX(this Vector3 v) => new(v.y, v.y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYXX(this Vector3 v) => new(v.z, v.y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYXX(this Vector3 v, float x = 0.0f) => new(x, v.y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZXX(this Vector3 v) => new(v.y, v.z, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZXX(this Vector3 v) => new(v.z, v.z, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZXX(this Vector3 v, float x = 0.0f) => new(x, v.z, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNXX(this Vector3 v, float y = 0.0f) => new(v.y, y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNXX(this Vector3 v, float y = 0.0f) => new(v.z, y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNXX(this Vector3 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYXY(this Vector3 v) => new(v.y, v.y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYXY(this Vector3 v) => new(v.z, v.y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYXY(this Vector3 v, float x = 0.0f) => new(x, v.y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZXY(this Vector3 v) => new(v.y, v.z, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZXY(this Vector3 v) => new(v.z, v.z, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZXY(this Vector3 v, float x = 0.0f) => new(x, v.z, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNXY(this Vector3 v, float y = 0.0f) => new(v.y, y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNXY(this Vector3 v, float y = 0.0f) => new(v.z, y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNXY(this Vector3 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYXZ(this Vector3 v) => new(v.y, v.y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYXZ(this Vector3 v) => new(v.z, v.y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYXZ(this Vector3 v, float x = 0.0f) => new(x, v.y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZXZ(this Vector3 v) => new(v.y, v.z, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZXZ(this Vector3 v) => new(v.z, v.z, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZXZ(this Vector3 v, float x = 0.0f) => new(x, v.z, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNXZ(this Vector3 v, float y = 0.0f) => new(v.y, y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNXZ(this Vector3 v, float y = 0.0f) => new(v.z, y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNXZ(this Vector3 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYXN(this Vector3 v, float w = 0.0f) => new(v.y, v.y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYXN(this Vector3 v, float w = 0.0f) => new(v.z, v.y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYXN(this Vector3 v, float x = 0.0f, float w = 0.0f) => new(x, v.y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZXN(this Vector3 v, float w = 0.0f) => new(v.y, v.z, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZXN(this Vector3 v, float w = 0.0f) => new(v.z, v.z, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZXN(this Vector3 v, float x = 0.0f, float w = 0.0f) => new(x, v.z, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNXN(this Vector3 v, float y = 0.0f, float w = 0.0f) => new(v.y, y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNXN(this Vector3 v, float y = 0.0f, float w = 0.0f) => new(v.z, y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNXN(this Vector3 v, float x = 0.0f, float y = 0.0f, float w = 0.0f) => new(x, y, v.x, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYYX(this Vector3 v) => new(v.y, v.y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYYX(this Vector3 v) => new(v.z, v.y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYYX(this Vector3 v, float x = 0.0f) => new(x, v.y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZYX(this Vector3 v) => new(v.y, v.z, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZYX(this Vector3 v) => new(v.z, v.z, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZYX(this Vector3 v, float x = 0.0f) => new(x, v.z, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNYX(this Vector3 v, float y = 0.0f) => new(v.y, y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNYX(this Vector3 v, float y = 0.0f) => new(v.z, y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNYX(this Vector3 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYZX(this Vector3 v) => new(v.y, v.y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYZX(this Vector3 v) => new(v.z, v.y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYZX(this Vector3 v, float x = 0.0f) => new(x, v.y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZZX(this Vector3 v) => new(v.y, v.z, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZZX(this Vector3 v) => new(v.z, v.z, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZZX(this Vector3 v, float x = 0.0f) => new(x, v.z, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNZX(this Vector3 v, float y = 0.0f) => new(v.y, y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNZX(this Vector3 v, float y = 0.0f) => new(v.z, y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNZX(this Vector3 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYNX(this Vector3 v, float z = 0.0f) => new(v.y, v.y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYNX(this Vector3 v, float z = 0.0f) => new(v.z, v.y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYNX(this Vector3 v, float x = 0.0f, float z = 0.0f) => new(x, v.y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZNX(this Vector3 v, float z = 0.0f) => new(v.y, v.z, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZNX(this Vector3 v, float z = 0.0f) => new(v.z, v.z, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZNX(this Vector3 v, float x = 0.0f, float z = 0.0f) => new(x, v.z, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNNX(this Vector3 v, float y = 0.0f, float z = 0.0f) => new(v.y, y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNNX(this Vector3 v, float y = 0.0f, float z = 0.0f) => new(v.z, y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNNX(this Vector3 v, float x = 0.0f, float y = 0.0f, float z = 0.0f) => new(x, y, z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYYY(this Vector3 v) => new(v.y, v.y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYYY(this Vector3 v) => new(v.z, v.y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYYY(this Vector3 v, float x = 0.0f) => new(x, v.y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZYY(this Vector3 v) => new(v.y, v.z, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZYY(this Vector3 v) => new(v.z, v.z, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZYY(this Vector3 v, float x = 0.0f) => new(x, v.z, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNYY(this Vector3 v, float y = 0.0f) => new(v.y, y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNYY(this Vector3 v, float y = 0.0f) => new(v.z, y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNYY(this Vector3 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYZY(this Vector3 v) => new(v.y, v.y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYZY(this Vector3 v) => new(v.z, v.y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYZY(this Vector3 v, float x = 0.0f) => new(x, v.y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZZY(this Vector3 v) => new(v.y, v.z, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZZY(this Vector3 v) => new(v.z, v.z, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZZY(this Vector3 v, float x = 0.0f) => new(x, v.z, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNZY(this Vector3 v, float y = 0.0f) => new(v.y, y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNZY(this Vector3 v, float y = 0.0f) => new(v.z, y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNZY(this Vector3 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYNY(this Vector3 v, float z = 0.0f) => new(v.y, v.y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYNY(this Vector3 v, float z = 0.0f) => new(v.z, v.y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYNY(this Vector3 v, float x = 0.0f, float z = 0.0f) => new(x, v.y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZNY(this Vector3 v, float z = 0.0f) => new(v.y, v.z, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZNY(this Vector3 v, float z = 0.0f) => new(v.z, v.z, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZNY(this Vector3 v, float x = 0.0f, float z = 0.0f) => new(x, v.z, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNNY(this Vector3 v, float y = 0.0f, float z = 0.0f) => new(v.y, y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNNY(this Vector3 v, float y = 0.0f, float z = 0.0f) => new(v.z, y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNNY(this Vector3 v, float x = 0.0f, float y = 0.0f, float z = 0.0f) => new(x, y, z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYYZ(this Vector3 v) => new(v.y, v.y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYYZ(this Vector3 v) => new(v.z, v.y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYYZ(this Vector3 v, float x = 0.0f) => new(x, v.y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZYZ(this Vector3 v) => new(v.y, v.z, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZYZ(this Vector3 v) => new(v.z, v.z, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZYZ(this Vector3 v, float x = 0.0f) => new(x, v.z, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNYZ(this Vector3 v, float y = 0.0f) => new(v.y, y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNYZ(this Vector3 v, float y = 0.0f) => new(v.z, y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNYZ(this Vector3 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYZZ(this Vector3 v) => new(v.y, v.y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYZZ(this Vector3 v) => new(v.z, v.y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYZZ(this Vector3 v, float x = 0.0f) => new(x, v.y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZZZ(this Vector3 v) => new(v.y, v.z, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZZZ(this Vector3 v) => new(v.z, v.z, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZZZ(this Vector3 v, float x = 0.0f) => new(x, v.z, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNZZ(this Vector3 v, float y = 0.0f) => new(v.y, y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNZZ(this Vector3 v, float y = 0.0f) => new(v.z, y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNZZ(this Vector3 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYNZ(this Vector3 v, float z = 0.0f) => new(v.y, v.y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYNZ(this Vector3 v, float z = 0.0f) => new(v.z, v.y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYNZ(this Vector3 v, float x = 0.0f, float z = 0.0f) => new(x, v.y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZNZ(this Vector3 v, float z = 0.0f) => new(v.y, v.z, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZNZ(this Vector3 v, float z = 0.0f) => new(v.z, v.z, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZNZ(this Vector3 v, float x = 0.0f, float z = 0.0f) => new(x, v.z, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNNZ(this Vector3 v, float y = 0.0f, float z = 0.0f) => new(v.y, y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNNZ(this Vector3 v, float y = 0.0f, float z = 0.0f) => new(v.z, y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNNZ(this Vector3 v, float x = 0.0f, float y = 0.0f, float z = 0.0f) => new(x, y, z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYYN(this Vector3 v, float w = 0.0f) => new(v.y, v.y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYYN(this Vector3 v, float w = 0.0f) => new(v.z, v.y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYYN(this Vector3 v, float x = 0.0f, float w = 0.0f) => new(x, v.y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZYN(this Vector3 v, float w = 0.0f) => new(v.y, v.z, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZYN(this Vector3 v, float w = 0.0f) => new(v.z, v.z, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZYN(this Vector3 v, float x = 0.0f, float w = 0.0f) => new(x, v.z, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNYN(this Vector3 v, float y = 0.0f, float w = 0.0f) => new(v.y, y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNYN(this Vector3 v, float y = 0.0f, float w = 0.0f) => new(v.z, y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNYN(this Vector3 v, float x = 0.0f, float y = 0.0f, float w = 0.0f) => new(x, y, v.y, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYZN(this Vector3 v, float w = 0.0f) => new(v.y, v.y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYZN(this Vector3 v, float w = 0.0f) => new(v.z, v.y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYZN(this Vector3 v, float x = 0.0f, float w = 0.0f) => new(x, v.y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZZN(this Vector3 v, float w = 0.0f) => new(v.y, v.z, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZZN(this Vector3 v, float w = 0.0f) => new(v.z, v.z, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZZN(this Vector3 v, float x = 0.0f, float w = 0.0f) => new(x, v.z, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNZN(this Vector3 v, float y = 0.0f, float w = 0.0f) => new(v.y, y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNZN(this Vector3 v, float y = 0.0f, float w = 0.0f) => new(v.z, y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NNZN(this Vector3 v, float x = 0.0f, float y = 0.0f, float w = 0.0f) => new(x, y, v.z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YYNN(this Vector3 v, float z = 0.0f, float w = 0.0f) => new(v.y, v.y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZYNN(this Vector3 v, float z = 0.0f, float w = 0.0f) => new(v.z, v.y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NYNN(this Vector3 v, float x = 0.0f, float z = 0.0f, float w = 0.0f) => new(x, v.y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YZNN(this Vector3 v, float z = 0.0f, float w = 0.0f) => new(v.y, v.z, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZZNN(this Vector3 v, float z = 0.0f, float w = 0.0f) => new(v.z, v.z, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 NZNN(this Vector3 v, float x = 0.0f, float z = 0.0f, float w = 0.0f) => new(x, v.z, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 YNNN(this Vector3 v, float y = 0.0f, float z = 0.0f, float w = 0.0f) => new(v.y, y, z, w);
        // ReSharper disable once InconsistentNaming
        public static Vector4 ZNNN(this Vector3 v, float y = 0.0f, float z = 0.0f, float w = 0.0f) => new(v.z, y, z, w);
    }
}
