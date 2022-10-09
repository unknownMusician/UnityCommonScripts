using System;

namespace AreYouFruits.Common
{
    public static class SerializedNullableExtensions
    {
        public static T? AsNullable<T>(SerializedNullable<T> serializedNullable)
            where T : struct, IEquatable<T>
        {
            return serializedNullable.HasValue ? serializedNullable.Value : (T?)null;
        }
    }
}