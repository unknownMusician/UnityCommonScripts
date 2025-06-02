using System;

namespace AreYouFruits.Ranges.Unity
{
    public static class RangeConversionExtensions
    {
        public static Range<TResult> Select<T, TResult>(this Range<T> range, Func<T, TResult> selector) => new(selector(range.Min), selector(range.Max));
    }
}
