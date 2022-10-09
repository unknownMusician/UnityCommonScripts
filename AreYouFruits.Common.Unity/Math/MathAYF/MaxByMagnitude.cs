using System;
using UnityEngine;

namespace AreYouFruits.Common.Math
{
    public static partial class MathAYF
    {
        public static Vector2Int MaxByMagnitude(ReadOnlySpan<Vector2Int> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            Vector2Int max = values[0];

            if (length == 1) { return max; }

            float minSqrMagnitude = max.sqrMagnitude;

            for (int i = 1; i < length; i++)
            {
                Vector2Int value = values[i];

                if (value.sqrMagnitude > minSqrMagnitude)
                {
                    max = value;
                }
            }

            return max;
        }

        public static Vector3Int MaxByMagnitude(ReadOnlySpan<Vector3Int> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            Vector3Int max = values[0];

            if (length == 1) { return max; }

            float minSqrMagnitude = max.sqrMagnitude;

            for (int i = 1; i < length; i++)
            {
                Vector3Int value = values[i];

                if (value.sqrMagnitude > minSqrMagnitude)
                {
                    max = value;
                }
            }

            return max;
        }

        public static Vector2 MaxByMagnitude(ReadOnlySpan<Vector2> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            Vector2 max = values[0];

            if (length == 1) { return max; }

            float minSqrMagnitude = max.sqrMagnitude;

            for (int i = 1; i < length; i++)
            {
                Vector2 value = values[i];

                if (value.sqrMagnitude > minSqrMagnitude)
                {
                    max = value;
                }
            }

            return max;
        }

        public static Vector3 MaxByMagnitude(ReadOnlySpan<Vector3> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            Vector3 max = values[0];

            if (length == 1) { return max; }

            float minSqrMagnitude = max.sqrMagnitude;

            for (int i = 1; i < length; i++)
            {
                Vector3 value = values[i];

                if (value.sqrMagnitude > minSqrMagnitude)
                {
                    max = value;
                }
            }

            return max;
        }

        public static Vector4 MaxByMagnitude(ReadOnlySpan<Vector4> values)
        {
            int length = values.Length;

            if (length == 0) { throw new ArgumentOutOfRangeException(); }

            Vector4 max = values[0];

            if (length == 1) { return max; }

            float minSqrMagnitude = max.sqrMagnitude;

            for (int i = 1; i < length; i++)
            {
                Vector4 value = values[i];

                if (value.sqrMagnitude > minSqrMagnitude)
                {
                    max = value;
                }
            }

            return max;
        }
    }
}

