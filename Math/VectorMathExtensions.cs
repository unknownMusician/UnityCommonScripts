using UnityEngine;

namespace AreYouFruits.Common.Math
{
    public static class VectorMathExtensions
    {
        public static Vector2Int DivideBy(this Vector2Int v1, Vector2Int v2)
        {
            return new Vector2Int(v1.x / v2.x, v1.y / v2.y);
        }

        public static Vector3Int DivideBy(this Vector3Int v1, Vector3Int v2)
        {
            return new Vector3Int(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }
        
        public static Vector2 DivideBy(this Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x / v2.x, v1.y / v2.y);
        }

        public static Vector3 DivideBy(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }

        public static Vector4 DivideBy(this Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z, v1.w / v2.w);
        }

        public static Vector2 DroppedSign(this Vector2 v)
        {
            return new Vector2(Mathf.Abs(v.x), Mathf.Abs(v.y));
        }

        public static Vector3 DroppedSign(this Vector3 v)
        {
            return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
        }

        public static Vector4 DroppedSign(this Vector4 v)
        {
            return new Vector4(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z), Mathf.Abs(v.w));
        }

        public static Vector2Int DroppedSign(this Vector2Int v)
        {
            return new Vector2Int(Mathf.Abs(v.x), Mathf.Abs(v.y));
        }

        public static Vector3Int DroppedSign(this Vector3Int v)
        {
            return new Vector3Int(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
        }
    }
}
