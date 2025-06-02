using UnityEngine;

namespace AreYouFruits.Math.Unity
{
    public static class QuaternionDeconstructionExtensions
    {
        public static void Deconstruct(this Quaternion q, out float x, out float y, out float z, out float w)
        {
            (x, y, z, w) = (q.x, q.y, q.z, q.w);
        }
    }
}
