﻿using UnityEngine;

namespace AreYouFruits.Common
{
    public static partial class RangeExtensions
    {
        public static float Random(this Range<float> range)
        {
            float min;
            float max;

            if (range.IsBound)
            {
                (min, max) = range;
            }
            else
            {
                min = float.MinValue;
                max = float.MaxValue;
            }

            return UnityEngine.Random.Range(min, max);
        }

        public static float Random(this Range<int> range)
        {
            float min;
            float max;

            if (range.IsBound)
            {
                (int minInt, int maxInt) = range;
                min = minInt;
                max = maxInt;
            }
            else
            {
                min = int.MinValue;
                max = int.MaxValue;
            }

            return UnityEngine.Random.Range(min, max);
        }

        public static int RandomInt(this Range<int> range)
        {
            int min;
            int max;

            if (range.IsBound)
            {
                (min, max) = range;
            }
            else
            {
                min = int.MinValue;
                max = int.MaxValue;
            }

            return UnityEngine.Random.Range(min, max);
        }

    
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

