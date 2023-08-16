using UnityEngine;

namespace AreYouFruits.Common.Math
{
    public static class QuaternionDeconstructionExtensions
    {
        public static void Deconstruct(this Quaternion q, out float x, out float y, out float z, out float w)
        {
            (x, y, z, w) = (q.x, q.y, q.z, q.w);
        }
    }
}
