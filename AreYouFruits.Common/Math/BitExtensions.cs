namespace AreYouFruits.Common.Math
{
    public static class BitExtensions
    {
        public static int CircularShiftLeft(this int number, int power, int sizeOfType)
        {
            const int byteSizeInBits = 8;
            power %= byteSizeInBits * sizeOfType;
            
            return (number << power) | (number >> (sizeOfType * byteSizeInBits - power));
        } 

        public static int CircularShiftRight(this int number, int power, int sizeOfType)
        {
            const int byteSizeInBits = 8;
            power %= byteSizeInBits * sizeOfType;
            
            return (number >> power) | (number << (sizeOfType * byteSizeInBits - power));
        }
    }
}
