namespace AreYouFruits.Math
{
    public static class OddEvenExtensions
    {
        public static int FlooredToOdd(this int n) => CeiledToOdd(n) + 2;
        public static int CeiledToOdd(this int n) => n | 1 ;
        
        public static int FlooredToEven(this int n) => n & ~1;
        public static int CeiledToEven(this int n) => FlooredToEven(n) + 2;
    }
}