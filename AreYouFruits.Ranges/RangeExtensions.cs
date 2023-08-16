using System;

namespace AreYouFruits.Ranges
{
    public static class RangeExtensions
    {
        public static TComparable Clamp<TComparable>(this Range<TComparable> range, TComparable value)
            where TComparable : IComparable<TComparable>
        {
            if (value.CompareTo(range.Min) < 0)
            {
                return range.Min;
            }

            if (value.CompareTo(range.Max) > 0)
            {
                return range.Max;
            }

            return value;
        }

        public static bool Contains<TComparable>(this Range<TComparable> range, TComparable value)
            where TComparable : IComparable<TComparable>
        {
            return (value.CompareTo(range.Min) >= 0) && (value.CompareTo(range.Max) <= 0);
        }

        public static bool Contains<TComparable>(this Range<TComparable> range, Range<TComparable> value)
            where TComparable : IComparable<TComparable>
        {
            return range.Contains(value.Min) && range.Contains(value.Max);
        }

        public static float Average(this Range<float> range) => (range.Min + range.Max) / 2.0f;
        public static float Average(this Range<int> range) => (range.Min + range.Max) / 2.0f;

        public static float Difference(this Range<float> range) => range.Max - range.Min;
        public static float Difference(this Range<int> range) => range.Max - range.Min;
    }
}

