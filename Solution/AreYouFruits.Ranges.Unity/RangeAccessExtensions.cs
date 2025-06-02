using UnityEngine;

namespace AreYouFruits.Ranges.Unity
{
    public static class RangeAccessExtensions
    {
        public static Range<float> R(this Range<Color> range) => range.Select(static v => v.r);
        public static Range<float> G(this Range<Color> range) => range.Select(static v => v.g);
        public static Range<float> B(this Range<Color> range) => range.Select(static v => v.b);
        public static Range<float> A(this Range<Color> range) => range.Select(static v => v.a);
        public static Range<float> X(this Range<Vector2> range) => range.Select(static v => v.x);
        public static Range<float> Y(this Range<Vector2> range) => range.Select(static v => v.y);
        public static Range<float> X(this Range<Vector3> range) => range.Select(static v => v.x);
        public static Range<float> Y(this Range<Vector3> range) => range.Select(static v => v.y);
        public static Range<float> Z(this Range<Vector3> range) => range.Select(static v => v.z);
        public static Range<float> X(this Range<Vector4> range) => range.Select(static v => v.x);
        public static Range<float> Y(this Range<Vector4> range) => range.Select(static v => v.y);
        public static Range<float> Z(this Range<Vector4> range) => range.Select(static v => v.z);
        public static Range<float> W(this Range<Vector4> range) => range.Select(static v => v.w);
        public static Range<float> X(this Range<Quaternion> range) => range.Select(static v => v.x);
        public static Range<float> Y(this Range<Quaternion> range) => range.Select(static v => v.y);
        public static Range<float> Z(this Range<Quaternion> range) => range.Select(static v => v.z);
        public static Range<float> W(this Range<Quaternion> range) => range.Select(static v => v.w);
    }
}
