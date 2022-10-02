#if UNITY_2021_3_OR_NEWER
using System;
using UnityEngine;

namespace AreYouFruits.Common.Math
{
    public static partial class MathAYF
    {
        public static Vector2Int MinByMagnitude(ReadOnlySpan<Vector2Int> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            Vector2Int min = values[0];

            if (length == 1) { return min; }

            float minSqrMagnitude = min.sqrMagnitude;

            for (int i = 1; i < length; i++)
            {
                Vector2Int value = values[i];

                if (value.sqrMagnitude < minSqrMagnitude)
                {
                    min = value;
                }
            }

            return min;
        }

        public static Vector3Int MinByMagnitude(ReadOnlySpan<Vector3Int> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            Vector3Int min = values[0];

            if (length == 1) { return min; }

            float minSqrMagnitude = min.sqrMagnitude;

            for (int i = 1; i < length; i++)
            {
                Vector3Int value = values[i];

                if (value.sqrMagnitude < minSqrMagnitude)
                {
                    min = value;
                }
            }

            return min;
        }

        public static Vector2 MinByMagnitude(ReadOnlySpan<Vector2> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            Vector2 min = values[0];

            if (length == 1) { return min; }

            float minSqrMagnitude = min.sqrMagnitude;

            for (int i = 1; i < length; i++)
            {
                Vector2 value = values[i];

                if (value.sqrMagnitude < minSqrMagnitude)
                {
                    min = value;
                }
            }

            return min;
        }

        public static Vector3 MinByMagnitude(ReadOnlySpan<Vector3> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            Vector3 min = values[0];

            if (length == 1) { return min; }

            float minSqrMagnitude = min.sqrMagnitude;

            for (int i = 1; i < length; i++)
            {
                Vector3 value = values[i];

                if (value.sqrMagnitude < minSqrMagnitude)
                {
                    min = value;
                }
            }

            return min;
        }

        public static Vector4 MinByMagnitude(ReadOnlySpan<Vector4> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            Vector4 min = values[0];

            if (length == 1) { return min; }

            float minSqrMagnitude = min.sqrMagnitude;

            for (int i = 1; i < length; i++)
            {
                Vector4 value = values[i];

                if (value.sqrMagnitude < minSqrMagnitude)
                {
                    min = value;
                }
            }

            return min;
        }
    }
}

#endif