using UnityEngine;

namespace AreYouFruits.Common.Math
{
    public static class InputNormalizationExtensions
    {
        public static Vector2 NormalizedDiamond(this Vector2 v) => v / (Mathf.Abs(v.x) + Mathf.Abs(v.y));

        public static Vector2 ClampedDiamond(this Vector2 v, float maxClamp)
        {
            if (maxClamp <= 0)
            {
                Debug.Log("maxClamp has value less than or 0");
            }

            Vector2 normalized = v.NormalizedDiamond() * maxClamp;

            return v.magnitude > normalized.magnitude ? normalized : v;
        }
    }
}
