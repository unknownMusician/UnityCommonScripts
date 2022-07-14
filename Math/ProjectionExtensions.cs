using UnityEngine;

namespace AreYouFruits.Common.Math
{
    // todo: add Vector4 and all Vector*Int support
    public static class ProjectionExtensions
    {
        public static Vector2 ProjectedXY(this Vector3 v) => new Vector2(v.x, v.y);
        public static Vector2 ProjectedXZ(this Vector3 v) => new Vector2(v.x, v.z);
        public static Vector2 ProjectedYX(this Vector3 v) => new Vector2(v.y, v.x);
        public static Vector2 ProjectedYZ(this Vector3 v) => new Vector2(v.y, v.z);
        public static Vector2 ProjectedZX(this Vector3 v) => new Vector2(v.z, v.x);
        public static Vector2 ProjectedZY(this Vector3 v) => new Vector2(v.z, v.y);

        public static Vector3 ReProjectedXY(this Vector2 v, float newZ = 0) => new Vector3(v.x, v.y, newZ);
        public static Vector3 ReProjectedXZ(this Vector2 v, float newY = 0) => new Vector3(v.x, newY, v.y);
        public static Vector3 ReProjectedYX(this Vector2 v, float newZ = 0) => new Vector3(v.y, v.x, newZ);
        public static Vector3 ReProjectedYZ(this Vector2 v, float newX = 0) => new Vector3(newX, v.x, v.y);
        public static Vector3 ReProjectedZX(this Vector2 v, float newY = 0) => new Vector3(v.y, newY, v.x);
        public static Vector3 ReProjectedZY(this Vector2 v, float newX = 0) => new Vector3(newX, v.y, v.x);
    }
}
