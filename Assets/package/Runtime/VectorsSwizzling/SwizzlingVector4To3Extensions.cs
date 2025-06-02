using UnityEngine;

namespace AreYouFruits.VectorsSwizzling
{
    public static class SwizzlingVector4To3Extensions
    {
        // ReSharper disable once InconsistentNaming
        public static Vector3 XXX(this Vector4 v) => new(v.x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XXY(this Vector4 v) => new(v.x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XXZ(this Vector4 v) => new(v.x, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XXW(this Vector4 v) => new(v.x, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XXN(this Vector4 v, float z = 0.0f) => new(v.x, v.x, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XYX(this Vector4 v) => new(v.x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XZX(this Vector4 v) => new(v.x, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XWX(this Vector4 v) => new(v.x, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XNX(this Vector4 v, float y = 0.0f) => new(v.x, y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XYY(this Vector4 v) => new(v.x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XZY(this Vector4 v) => new(v.x, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XWY(this Vector4 v) => new(v.x, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XNY(this Vector4 v, float y = 0.0f) => new(v.x, y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XYZ(this Vector4 v) => new(v.x, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XZZ(this Vector4 v) => new(v.x, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XWZ(this Vector4 v) => new(v.x, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XNZ(this Vector4 v, float y = 0.0f) => new(v.x, y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XYW(this Vector4 v) => new(v.x, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XZW(this Vector4 v) => new(v.x, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XWW(this Vector4 v) => new(v.x, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XNW(this Vector4 v, float y = 0.0f) => new(v.x, y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XYN(this Vector4 v, float z = 0.0f) => new(v.x, v.y, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XZN(this Vector4 v, float z = 0.0f) => new(v.x, v.z, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XWN(this Vector4 v, float z = 0.0f) => new(v.x, v.w, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 XNN(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.x, y, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YXX(this Vector4 v) => new(v.y, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZXX(this Vector4 v) => new(v.z, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WXX(this Vector4 v) => new(v.w, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NXX(this Vector4 v, float x = 0.0f) => new(x, v.x, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YXY(this Vector4 v) => new(v.y, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZXY(this Vector4 v) => new(v.z, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WXY(this Vector4 v) => new(v.w, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NXY(this Vector4 v, float x = 0.0f) => new(x, v.x, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YXZ(this Vector4 v) => new(v.y, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZXZ(this Vector4 v) => new(v.z, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WXZ(this Vector4 v) => new(v.w, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NXZ(this Vector4 v, float x = 0.0f) => new(x, v.x, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YXW(this Vector4 v) => new(v.y, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZXW(this Vector4 v) => new(v.z, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WXW(this Vector4 v) => new(v.w, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NXW(this Vector4 v, float x = 0.0f) => new(x, v.x, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YXN(this Vector4 v, float z = 0.0f) => new(v.y, v.x, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZXN(this Vector4 v, float z = 0.0f) => new(v.z, v.x, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WXN(this Vector4 v, float z = 0.0f) => new(v.w, v.x, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NXN(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.x, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YYX(this Vector4 v) => new(v.y, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZYX(this Vector4 v) => new(v.z, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WYX(this Vector4 v) => new(v.w, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NYX(this Vector4 v, float x = 0.0f) => new(x, v.y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YZX(this Vector4 v) => new(v.y, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZZX(this Vector4 v) => new(v.z, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WZX(this Vector4 v) => new(v.w, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NZX(this Vector4 v, float x = 0.0f) => new(x, v.z, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YWX(this Vector4 v) => new(v.y, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZWX(this Vector4 v) => new(v.z, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WWX(this Vector4 v) => new(v.w, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NWX(this Vector4 v, float x = 0.0f) => new(x, v.w, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YNX(this Vector4 v, float y = 0.0f) => new(v.y, y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZNX(this Vector4 v, float y = 0.0f) => new(v.z, y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WNX(this Vector4 v, float y = 0.0f) => new(v.w, y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NNX(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.x);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YYY(this Vector4 v) => new(v.y, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZYY(this Vector4 v) => new(v.z, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WYY(this Vector4 v) => new(v.w, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NYY(this Vector4 v, float x = 0.0f) => new(x, v.y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YZY(this Vector4 v) => new(v.y, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZZY(this Vector4 v) => new(v.z, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WZY(this Vector4 v) => new(v.w, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NZY(this Vector4 v, float x = 0.0f) => new(x, v.z, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YWY(this Vector4 v) => new(v.y, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZWY(this Vector4 v) => new(v.z, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WWY(this Vector4 v) => new(v.w, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NWY(this Vector4 v, float x = 0.0f) => new(x, v.w, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YNY(this Vector4 v, float y = 0.0f) => new(v.y, y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZNY(this Vector4 v, float y = 0.0f) => new(v.z, y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WNY(this Vector4 v, float y = 0.0f) => new(v.w, y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NNY(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.y);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YYZ(this Vector4 v) => new(v.y, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZYZ(this Vector4 v) => new(v.z, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WYZ(this Vector4 v) => new(v.w, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NYZ(this Vector4 v, float x = 0.0f) => new(x, v.y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YZZ(this Vector4 v) => new(v.y, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZZZ(this Vector4 v) => new(v.z, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WZZ(this Vector4 v) => new(v.w, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NZZ(this Vector4 v, float x = 0.0f) => new(x, v.z, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YWZ(this Vector4 v) => new(v.y, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZWZ(this Vector4 v) => new(v.z, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WWZ(this Vector4 v) => new(v.w, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NWZ(this Vector4 v, float x = 0.0f) => new(x, v.w, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YNZ(this Vector4 v, float y = 0.0f) => new(v.y, y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZNZ(this Vector4 v, float y = 0.0f) => new(v.z, y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WNZ(this Vector4 v, float y = 0.0f) => new(v.w, y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NNZ(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YYW(this Vector4 v) => new(v.y, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZYW(this Vector4 v) => new(v.z, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WYW(this Vector4 v) => new(v.w, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NYW(this Vector4 v, float x = 0.0f) => new(x, v.y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YZW(this Vector4 v) => new(v.y, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZZW(this Vector4 v) => new(v.z, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WZW(this Vector4 v) => new(v.w, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NZW(this Vector4 v, float x = 0.0f) => new(x, v.z, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YWW(this Vector4 v) => new(v.y, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZWW(this Vector4 v) => new(v.z, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WWW(this Vector4 v) => new(v.w, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NWW(this Vector4 v, float x = 0.0f) => new(x, v.w, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YNW(this Vector4 v, float y = 0.0f) => new(v.y, y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZNW(this Vector4 v, float y = 0.0f) => new(v.z, y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WNW(this Vector4 v, float y = 0.0f) => new(v.w, y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NNW(this Vector4 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.w);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YYN(this Vector4 v, float z = 0.0f) => new(v.y, v.y, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZYN(this Vector4 v, float z = 0.0f) => new(v.z, v.y, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WYN(this Vector4 v, float z = 0.0f) => new(v.w, v.y, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NYN(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.y, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YZN(this Vector4 v, float z = 0.0f) => new(v.y, v.z, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZZN(this Vector4 v, float z = 0.0f) => new(v.z, v.z, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WZN(this Vector4 v, float z = 0.0f) => new(v.w, v.z, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NZN(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.z, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YWN(this Vector4 v, float z = 0.0f) => new(v.y, v.w, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZWN(this Vector4 v, float z = 0.0f) => new(v.z, v.w, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WWN(this Vector4 v, float z = 0.0f) => new(v.w, v.w, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 NWN(this Vector4 v, float x = 0.0f, float z = 0.0f) => new(x, v.w, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 YNN(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.y, y, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 ZNN(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.z, y, z);
        // ReSharper disable once InconsistentNaming
        public static Vector3 WNN(this Vector4 v, float y = 0.0f, float z = 0.0f) => new(v.w, y, z);
    }
}
