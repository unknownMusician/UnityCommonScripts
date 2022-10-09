using System;
using System.Collections.Generic;

namespace AreYouFruits.Common
{
    public static class EnumUtils<TEnum>
        where TEnum : struct, Enum
    {
        private static readonly Dictionary<TEnum, string> Names = new Dictionary<TEnum, string>();

        static EnumUtils()
        {
            foreach (TEnum value in (TEnum[])Enum.GetValues(typeof(TEnum)))
            {
                Names.Add(value, value.ToString());
            }
        }
        
        public static string CachedToString(TEnum value)
        {
            return Names.TryGetValue(value, out string? name) ? name : value.ToString();
        }
    }
}