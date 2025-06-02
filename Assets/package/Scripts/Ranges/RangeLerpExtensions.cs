using UnityEngine;

namespace AreYouFruits.Ranges.Unity
{
    public static class RangeLerpExtensions
    {
        public static float Lerp(this Range<float> range, float t) => Mathf.Lerp(range.Min, range.Max, t);
        public static Color Lerp(this Range<Color> range, float t) => Color.Lerp(range.Min, range.Max, t);
        public static Vector2 Lerp(this Range<Vector2> range, float t) => Vector2.Lerp(range.Min, range.Max, t);
        public static Vector3 Lerp(this Range<Vector3> range, float t) => Vector3.Lerp(range.Min, range.Max, t);
        public static Vector3 Slerp(this Range<Vector3> range, float t) => Vector3.Slerp(range.Min, range.Max, t);
        public static Vector4 Lerp(this Range<Vector4> range, float t) => Vector4.Lerp(range.Min, range.Max, t);

        public static Quaternion Lerp(this Range<Quaternion> range, float t)
        {
            return Quaternion.Lerp(range.Min, range.Max, t);
        }

        public static Quaternion Slerp(this Range<Quaternion> range, float t)
        {
            return Quaternion.Slerp(range.Min, range.Max, t);
        }
    }
}

