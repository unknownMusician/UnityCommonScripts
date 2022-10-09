using System;

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
    }
}