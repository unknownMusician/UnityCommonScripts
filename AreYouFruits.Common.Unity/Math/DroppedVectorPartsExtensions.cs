using UnityEngine;

namespace AreYouFruits.Common.Math
{
    public static class DroppedVectorPartsExtensions
    {
        public static Vector4 DroppedX(this Vector4 v, float newX = 0) => new(newX, v.y, v.z, v.w);
        public static Vector4 DroppedY(this Vector4 v, float newY = 0) => new(v.x, newY, v.z, v.w);
        public static Vector4 DroppedZ(this Vector4 v, float newZ = 0) => new(v.x, v.y, newZ, v.w);
        public static Vector4 DroppedW(this Vector4 v, float newW = 0) => new(v.x, v.y, v.z, newW);

        public static Vector3 DroppedX(this Vector3 v, float newX = 0) => new(newX, v.y, v.z);
        public static Vector3 DroppedY(this Vector3 v, float newY = 0) => new(v.x, newY, v.z);
        public static Vector3 DroppedZ(this Vector3 v, float newZ = 0) => new(v.x, v.y, newZ);

        public static Vector3Int DroppedX(this Vector3Int v, int newX = 0) => new(newX, v.y, v.z);
        public static Vector3Int DroppedY(this Vector3Int v, int newY = 0) => new(v.x, newY, v.z);
        public static Vector3Int DroppedZ(this Vector3Int v, int newZ = 0) => new(v.x, v.y, newZ);

        public static Vector2 DroppedX(this Vector2 v, float newX = 0) => new(newX, v.y);
        public static Vector2 DroppedY(this Vector2 v, float newY = 0) => new(v.x, newY);

        public static Vector2Int DroppedX(this Vector2Int v, int newX = 0) => new(newX, v.y);
        public static Vector2Int DroppedY(this Vector2Int v, int newY = 0) => new(v.x, newY);
    }
}
