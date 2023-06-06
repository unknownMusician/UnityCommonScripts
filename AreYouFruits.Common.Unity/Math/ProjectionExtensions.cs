using UnityEngine;

namespace AreYouFruits.Common.Math
{
    // todo: add Vector4 and all Vector*Int support
    public static class ProjectionExtensions
    {
        public static Vector2 XY(this Vector3 v) => new Vector2(v.x, v.y);
        public static Vector2 XZ(this Vector3 v) => new Vector2(v.x, v.z);
        public static Vector2 YX(this Vector3 v) => new Vector2(v.y, v.x);
        public static Vector2 YZ(this Vector3 v) => new Vector2(v.y, v.z);
        public static Vector2 ZX(this Vector3 v) => new Vector2(v.z, v.x);
        public static Vector2 ZY(this Vector3 v) => new Vector2(v.z, v.y);

        public static Vector3 AsXY(this Vector2 v, float newZ = 0) => new Vector3(v.x, v.y, newZ);
        public static Vector3 AsXZ(this Vector2 v, float newY = 0) => new Vector3(v.x, newY, v.y);
        public static Vector3 AsYX(this Vector2 v, float newZ = 0) => new Vector3(v.y, v.x, newZ);
        public static Vector3 AsYZ(this Vector2 v, float newX = 0) => new Vector3(newX, v.x, v.y);
        public static Vector3 AsZX(this Vector2 v, float newY = 0) => new Vector3(v.y, newY, v.x);
        public static Vector3 AsZY(this Vector2 v, float newX = 0) => new Vector3(newX, v.y, v.x);
    }
}

