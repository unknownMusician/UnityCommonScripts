namespace AreYouFruits.Common.Math
{
    public static partial class MathExtensions
    {
        public static int ToOdd(this int n) => n | 1;
        public static int ToEven(this int n) => n & ~1;
    }
}