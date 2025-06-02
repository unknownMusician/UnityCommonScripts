using UnityEngine;

namespace AreYouFruits.VectorsSwizzling
{
    public static class SwizzlingVector3To3Extensions
    {
        public static Vector3 XXX(this Vector3 v) => new(v.x, v.x, v.x);
        public static Vector3 XXY(this Vector3 v) => new(v.x, v.x, v.y);
        public static Vector3 XXZ(this Vector3 v) => new(v.x, v.x, v.z);
        public static Vector3 XXN(this Vector3 v, float z = 0.0f) => new(v.x, v.x, z);
        public static Vector3 XYX(this Vector3 v) => new(v.x, v.y, v.x);
        public static Vector3 XZX(this Vector3 v) => new(v.x, v.z, v.x);
        public static Vector3 XNX(this Vector3 v, float y = 0.0f) => new(v.x, y, v.x);
        public static Vector3 XYY(this Vector3 v) => new(v.x, v.y, v.y);
        public static Vector3 XZY(this Vector3 v) => new(v.x, v.z, v.y);
        public static Vector3 XNY(this Vector3 v, float y = 0.0f) => new(v.x, y, v.y);
        public static Vector3 XYZ(this Vector3 v) => new(v.x, v.y, v.z);
        public static Vector3 XZZ(this Vector3 v) => new(v.x, v.z, v.z);
        public static Vector3 XNZ(this Vector3 v, float y = 0.0f) => new(v.x, y, v.z);
        public static Vector3 XYN(this Vector3 v, float z = 0.0f) => new(v.x, v.y, z);
        public static Vector3 XZN(this Vector3 v, float z = 0.0f) => new(v.x, v.z, z);
        public static Vector3 XNN(this Vector3 v, float y = 0.0f, float z = 0.0f) => new(v.x, y, z);
        public static Vector3 YXX(this Vector3 v) => new(v.y, v.x, v.x);
        public static Vector3 ZXX(this Vector3 v) => new(v.z, v.x, v.x);
        public static Vector3 NXX(this Vector3 v, float x = 0.0f) => new(x, v.x, v.x);
        public static Vector3 YXY(this Vector3 v) => new(v.y, v.x, v.y);
        public static Vector3 ZXY(this Vector3 v) => new(v.z, v.x, v.y);
        public static Vector3 NXY(this Vector3 v, float x = 0.0f) => new(x, v.x, v.y);
        public static Vector3 YXZ(this Vector3 v) => new(v.y, v.x, v.z);
        public static Vector3 ZXZ(this Vector3 v) => new(v.z, v.x, v.z);
        public static Vector3 NXZ(this Vector3 v, float x = 0.0f) => new(x, v.x, v.z);
        public static Vector3 YXN(this Vector3 v, float z = 0.0f) => new(v.y, v.x, z);
        public static Vector3 ZXN(this Vector3 v, float z = 0.0f) => new(v.z, v.x, z);
        public static Vector3 NXN(this Vector3 v, float x = 0.0f, float z = 0.0f) => new(x, v.x, z);
        public static Vector3 YYX(this Vector3 v) => new(v.y, v.y, v.x);
        public static Vector3 ZYX(this Vector3 v) => new(v.z, v.y, v.x);
        public static Vector3 NYX(this Vector3 v, float x = 0.0f) => new(x, v.y, v.x);
        public static Vector3 YZX(this Vector3 v) => new(v.y, v.z, v.x);
        public static Vector3 ZZX(this Vector3 v) => new(v.z, v.z, v.x);
        public static Vector3 NZX(this Vector3 v, float x = 0.0f) => new(x, v.z, v.x);
        public static Vector3 YNX(this Vector3 v, float y = 0.0f) => new(v.y, y, v.x);
        public static Vector3 ZNX(this Vector3 v, float y = 0.0f) => new(v.z, y, v.x);
        public static Vector3 NNX(this Vector3 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.x);
        public static Vector3 YYY(this Vector3 v) => new(v.y, v.y, v.y);
        public static Vector3 ZYY(this Vector3 v) => new(v.z, v.y, v.y);
        public static Vector3 NYY(this Vector3 v, float x = 0.0f) => new(x, v.y, v.y);
        public static Vector3 YZY(this Vector3 v) => new(v.y, v.z, v.y);
        public static Vector3 ZZY(this Vector3 v) => new(v.z, v.z, v.y);
        public static Vector3 NZY(this Vector3 v, float x = 0.0f) => new(x, v.z, v.y);
        public static Vector3 YNY(this Vector3 v, float y = 0.0f) => new(v.y, y, v.y);
        public static Vector3 ZNY(this Vector3 v, float y = 0.0f) => new(v.z, y, v.y);
        public static Vector3 NNY(this Vector3 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.y);
        public static Vector3 YYZ(this Vector3 v) => new(v.y, v.y, v.z);
        public static Vector3 ZYZ(this Vector3 v) => new(v.z, v.y, v.z);
        public static Vector3 NYZ(this Vector3 v, float x = 0.0f) => new(x, v.y, v.z);
        public static Vector3 YZZ(this Vector3 v) => new(v.y, v.z, v.z);
        public static Vector3 ZZZ(this Vector3 v) => new(v.z, v.z, v.z);
        public static Vector3 NZZ(this Vector3 v, float x = 0.0f) => new(x, v.z, v.z);
        public static Vector3 YNZ(this Vector3 v, float y = 0.0f) => new(v.y, y, v.z);
        public static Vector3 ZNZ(this Vector3 v, float y = 0.0f) => new(v.z, y, v.z);
        public static Vector3 NNZ(this Vector3 v, float x = 0.0f, float y = 0.0f) => new(x, y, v.z);
        public static Vector3 YYN(this Vector3 v, float z = 0.0f) => new(v.y, v.y, z);
        public static Vector3 ZYN(this Vector3 v, float z = 0.0f) => new(v.z, v.y, z);
        public static Vector3 NYN(this Vector3 v, float x = 0.0f, float z = 0.0f) => new(x, v.y, z);
        public static Vector3 YZN(this Vector3 v, float z = 0.0f) => new(v.y, v.z, z);
        public static Vector3 ZZN(this Vector3 v, float z = 0.0f) => new(v.z, v.z, z);
        public static Vector3 NZN(this Vector3 v, float x = 0.0f, float z = 0.0f) => new(x, v.z, z);
        public static Vector3 YNN(this Vector3 v, float y = 0.0f, float z = 0.0f) => new(v.y, y, z);
        public static Vector3 ZNN(this Vector3 v, float y = 0.0f, float z = 0.0f) => new(v.z, y, z);
    }
}
