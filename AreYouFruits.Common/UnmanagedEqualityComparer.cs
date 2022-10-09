using System.Collections.Generic;

namespace AreYouFruits.Common
{
    public static unsafe class UnmanagedEqualityComparer
    {
        public static bool Equals<T>(T x, T y)
            where T : unmanaged
        {
            int sizeOfT = sizeof(T);
            
            byte* xPtr = (byte*)&x;
            byte* yPtr = (byte*)&y;

            for (int i = 0; i < sizeOfT; i++)
            {
                if (xPtr[i] != yPtr[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static int GetHashCode<T>(T value)
            where T : unmanaged
        {
            int hashCode = 0;
            
            int sizeOfT = sizeof(T);
            const int sizeOfInt = sizeof(int);

            byte* valuePtr = (byte*)&value;
            byte* hashCodePtr = (byte*)&hashCode;

            for (int i = 0; i < sizeOfT; i++)
            {
                hashCodePtr[i % sizeOfInt] ^= valuePtr[i];
            }

            return hashCode;
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