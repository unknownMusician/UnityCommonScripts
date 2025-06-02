using UnityEngine;

namespace AreYouFruits.Math.Unity
{
    public static class QuaternionExtensions
    {
        public static Quaternion SmoothDamp(
            this Quaternion current, Quaternion target, ref Quaternion velocity, float smoothTime
        )
        {
            float x = Mathf.SmoothDamp(current.x, target.x, ref velocity.x, smoothTime);
            float y = Mathf.SmoothDamp(current.y, target.y, ref velocity.y, smoothTime);
            float z = Mathf.SmoothDamp(current.z, target.z, ref velocity.z, smoothTime);
            float w = Mathf.SmoothDamp(current.w, target.w, ref velocity.w, smoothTime);

            return new Quaternion(x, y, z, w);
        }

        public static Quaternion To(this Quaternion origin, Quaternion destination)
        {
            return destination * Quaternion.Inverse(origin);
        }
    }
}

