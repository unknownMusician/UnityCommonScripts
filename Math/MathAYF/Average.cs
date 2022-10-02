using System;
using UnityEngine;

namespace AreYouFruits.Common.Math
{
    public static partial class MathAYF
    {
        public static float Average(ReadOnlySpan<int> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            float sum = 0;

            foreach (int value in values)
            {
                sum += (float)value / length;
            }

            return sum;
        }

        public static float Average(ReadOnlySpan<float> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            float sum = 0;

            foreach (float value in values)
            {
                sum += value / length;
            }

            return sum;
        }

    #if UNITY_2021_3_OR_NEWER
        public static Vector2 Average(ReadOnlySpan<Vector2> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            Vector2 sum = Vector2.zero;

            foreach (Vector2 value in values)
            {
                sum += value / length;
            }

            return sum;
        }

        public static Vector3 Average(ReadOnlySpan<Vector3> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            Vector3 sum = Vector3.zero;

            foreach (Vector3 value in values)
            {
                sum += value / length;
            }

            return sum;
        }

        public static Vector4 Average(ReadOnlySpan<Vector4> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            Vector4 sum = Vector4.zero;

            foreach (Vector4 value in values)
            {
                sum += value / length;
            }

            return sum;
        }

    #endif
    }
}