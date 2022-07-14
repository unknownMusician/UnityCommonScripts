using UnityEngine;

namespace AreYouFruits.Common.Math
{
    public static class MathExtensions
    {
        public static int ToOdd(this int n) => n | 1;
        public static int ToEven(this int n) => n & ~1;

        public static float GetCycleDegrees360(this float angle) => GetCycleDegrees(angle, 360f);
        public static float GetCycleDegrees180(this float angle) => GetCycleDegrees(angle, 180f);

        public static float GetCycleDegrees(this float angle, float cycleMaxAngle)
        {
            float fullCyclesAngle = 360f * Mathf.Floor((angle + 360f - cycleMaxAngle) * (1f / 360f));

            return angle - fullCyclesAngle;
        }

        public static float Area(this Vector2 v) => v.x * v.y;
        public static int Area(this Vector2Int v) => v.x * v.y;
        public static float Volume(this Vector3 v) => v.x * v.y * v.z;
        public static int Volume(this Vector3Int v) => v.x * v.y * v.z;
    }
}
