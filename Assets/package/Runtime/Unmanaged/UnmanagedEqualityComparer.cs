using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AreYouFruits.Unmanaged
{
    public static class UnmanagedEqualityComparer
    {
        public static bool Equals<T>(T x, T y)
            where T : unmanaged
        {
            var xSpan = MemoryMarshal.AsBytes(stackalloc[] { x });
            var ySpan = MemoryMarshal.AsBytes(stackalloc[] { y });
            
            return xSpan.SequenceEqual(ySpan);
        }

        public static int GetHashCode<T>(T value)
            where T : unmanaged
        {
            Span<int> hashCode = stackalloc[] { 0 };
            
            var valueSpan = MemoryMarshal.AsBytes(stackalloc[] { value });
            var hashCodeSpan = MemoryMarshal.AsBytes(hashCode);
            
            for (var i = 0; i < valueSpan.Length; i++)
            {
                var index = i % sizeof(int);
                
                if (index is 0)
                {
                    hashCode[0] *= 137;
                }
                
                hashCodeSpan[index] ^= valueSpan[i];
            }

            return hashCode[0];
        }

        public static int GetHashCode<T1, T2>(T1 t1, T2 t2)
            where T1 : unmanaged
            where T2 : unmanaged
        {
            unchecked
            {
                int hashCode = GetHashCode(t1);
                hashCode = (hashCode * 137) ^ GetHashCode(t2);

                return hashCode;
            }
        }

        public static int GetHashCode<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
            where T1 : unmanaged
            where T2 : unmanaged
            where T3 : unmanaged
        {
            unchecked
            {
                int hashCode = GetHashCode(t1);
                hashCode = (hashCode * 137) ^ GetHashCode(t2);
                hashCode = (hashCode * 137) ^ GetHashCode(t3);

                return hashCode;
            }
        }

        public static int GetHashCode<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4)
            where T1 : unmanaged
            where T2 : unmanaged
            where T3 : unmanaged
            where T4 : unmanaged
        {
            unchecked
            {
                int hashCode = GetHashCode(t1);
                hashCode = (hashCode * 137) ^ GetHashCode(t2);
                hashCode = (hashCode * 137) ^ GetHashCode(t3);
                hashCode = (hashCode * 137) ^ GetHashCode(t4);

                return hashCode;
            }
        }

        public static int GetHashCode<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
            where T1 : unmanaged
            where T2 : unmanaged
            where T3 : unmanaged
            where T4 : unmanaged
            where T5 : unmanaged
        {
            unchecked
            {
                int hashCode = GetHashCode(t1);
                hashCode = (hashCode * 137) ^ GetHashCode(t2);
                hashCode = (hashCode * 137) ^ GetHashCode(t3);
                hashCode = (hashCode * 137) ^ GetHashCode(t4);
                hashCode = (hashCode * 137) ^ GetHashCode(t5);

                return hashCode;
            }
        }
    }
    
    public readonly struct UnmanagedEqualityComparer<T> : IEqualityComparer<T>
        where T : unmanaged
    {
        public bool Equals(T x, T y)
        {
            return UnmanagedEqualityComparer.Equals(x, y);
        }

        public int GetHashCode(T value)
        {
            return UnmanagedEqualityComparer.GetHashCode(value);
        }
    }
}