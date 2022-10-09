using System;
using AreYouFruits.Common.Math;

namespace AreYouFruits.Common
{
    public static partial class RangeExtensions
    {
        public static TComparable Clamp<TComparable>(this Range<TComparable> range, TComparable value)
            where TComparable : IComparable<TComparable>
        {
            if (range.IsBounded)
            {
                if (value.CompareTo(range.Min) < 0)
                {
                    return range.Min;
                }

                if (value.CompareTo(range.Max) > 0)
                {
                    return range.Max;
                }
            }

            return value;
        }

        public static bool Contains<TComparable>(this Range<TComparable> range, TComparable value)
            where TComparable : IComparable<TComparable>
        {
            return !range.IsBounded || ((value.CompareTo(range.Min) >= 0) && (value.CompareTo(range.Max) <= 0));
        }

        public static bool Contains<TComparable>(this Range<TComparable> range, Range<TComparable> value)
            where TComparable : IComparable<TComparable>
        {
            return !range.IsBounded || (value.IsBounded && range.Contains(value.Min) && range.Contains(value.Max));
        }

        public static float Average(this Range<float> range)
        {
            return range.IsBounded ? MathAYF.Average(stackalloc[] { range.Min, range.Max }) : 0.0f;
        }

        public static float Average(this Range<int> range)
        {
            return range.IsBounded ? MathAYF.Average(stackalloc[] { range.Min, range.Max }) : 0.0f;
        }

        public static float Difference(this Range<float> range)
        {
            return range.IsBounded ? (range.Max - range.Min) : float.PositiveInfinity;
        }

        public static float Difference(this Range<int> range)
        {
            return range.IsBounded ? (range.Max - range.Min) : float.PositiveInfinity;
        }
    }
}

