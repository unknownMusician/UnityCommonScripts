﻿using UnityEngine;

namespace AreYouFruits.Common
{
    public static class MathExtensions
    {
        public static Vector2 SnappedToGrid(this Vector2 v)
        {
            return new Vector2(Mathf.Round(v.x + 0.5f) - 0.5f, Mathf.Round(v.y + 0.5f) - 0.5f);
        }

        public static Vector3 SnappedToGrid(this Vector3 v, bool keepY)
        {
            return new Vector3(Mathf.Round(v.x + 0.5f) - 0.5f, keepY ? v.y : 0, Mathf.Round(v.z + 0.5f) - 0.5f);
        }

        public static Vector3 SnappedToGrid(this Vector3 v, float newY)
        {
            return new Vector3(Mathf.Round(v.x + 0.5f) - 0.5f, newY, Mathf.Round(v.z + 0.5f) - 0.5f);
        }

        public static Vector2 ProjectedXY(this Vector3 v) => new Vector2(v.x, v.y);
        public static Vector2 ProjectedXZ(this Vector3 v) => new Vector2(v.x, v.z);
        public static Vector2 ProjectedYX(this Vector3 v) => new Vector2(v.y, v.x);
        public static Vector2 ProjectedYZ(this Vector3 v) => new Vector2(v.y, v.z);
        public static Vector2 ProjectedZX(this Vector3 v) => new Vector2(v.z, v.x);
        public static Vector2 ProjectedZY(this Vector3 v) => new Vector2(v.z, v.y);

        public static Vector3 ReProjectedXY(this Vector2 v, float newZ = 0) => new Vector3(v.x, v.y, newZ);
        public static Vector3 ReProjectedXZ(this Vector2 v, float newY = 0) => new Vector3(v.x, newY, v.y);
        public static Vector3 ReProjectedYX(this Vector2 v, float newZ = 0) => new Vector3(v.y, v.x, newZ);
        public static Vector3 ReProjectedYZ(this Vector2 v, float newX = 0) => new Vector3(newX, v.x, v.y);
        public static Vector3 ReProjectedZX(this Vector2 v, float newY = 0) => new Vector3(v.y, newY, v.x);
        public static Vector3 ReProjectedZY(this Vector2 v, float newX = 0) => new Vector3(newX, v.y, v.x);

        public static Vector3 DroppedX(this Vector3 v, float newX = 0) => new Vector3(newX, v.y, v.z);
        public static Vector3 DroppedY(this Vector3 v, float newY = 0) => new Vector3(v.x, newY, v.z);
        public static Vector3 DroppedZ(this Vector3 v, float newZ = 0) => new Vector3(v.x, v.y, newZ);

        public static Vector2 DroppedX(this Vector2 v, float newX = 0) => new Vector2(newX, v.y);
        public static Vector2 DroppedY(this Vector2 v, float newY = 0) => new Vector2(v.x, newY);

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

        public static void Deconstruct(this Vector2 v, out float x, out float y)
        {
            (x, y) = (v.x, v.y);
        }

        public static void Deconstruct(this Vector3 v, out float x, out float y, out float z)
        {
            (x, y, z) = (v.x, v.y, v.z);
        }

        public static void Deconstruct(this Vector4 v, out float x, out float y, out float z, out float w)
        {
            (x, y, z, w) = (v.x, v.y, v.z, v.w);
        }

        public static void Deconstruct(this Vector2Int v, out int x, out int y)
        {
            (x, y) = (v.x, v.y);
        }

        public static void Deconstruct(this Vector3Int v, out int x, out int y, out int z)
        {
            (x, y, z) = (v.x, v.y, v.z);
        }

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

        public static Vector2 DivideBy(this Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x / v2.x, v1.y / v2.y);
        }

        public static Vector3 DivideBy(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }

        public static Vector4 DivideBy(this Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z, v1.w / v2.w);
        }

        public static int ToOdd(this int n) => n | 1;
        public static int ToEven(this int n) => n & ~1;

        public static float GetCycleDegrees360(this float angle) => GetCycleDegrees(angle, 360f);
        public static float GetCycleDegrees180(this float angle) => GetCycleDegrees(angle, 180f);

        public static float GetCycleDegrees(this float angle, float cycleMaxAngle)
        {
            float fullCyclesAngle = 360f * Mathf.Floor((angle + 360f - cycleMaxAngle) * (1f / 360f));

            return angle - fullCyclesAngle;
        }

        public static bool EvaluateProbability(float randomValue, float probability) => randomValue < probability;
        public static bool EvaluateProbability(float probability) => EvaluateProbability(Random.value, probability);

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

        public static Vector2 DroppedSign(this Vector2 v)
        {
            return new Vector2(Mathf.Abs(v.x), Mathf.Abs(v.y));
        }

        public static Vector3 DroppedSign(this Vector3 v)
        {
            return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
        }

        public static Vector4 DroppedSign(this Vector4 v)
        {
            return new Vector4(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z), Mathf.Abs(v.w));
        }

        public static Vector2Int DroppedSign(this Vector2Int v)
        {
            return new Vector2Int(Mathf.Abs(v.x), Mathf.Abs(v.y));
        }

        public static Vector3Int DroppedSign(this Vector3Int v)
        {
            return new Vector3Int(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
        }

        public static float Area(this Vector2 v) => v.x * v.y;
        public static int Area(this Vector2Int v) => v.x * v.y;
        public static float Volume(this Vector3 v) => v.x * v.y * v.z;
        public static int Volume(this Vector3Int v) => v.x * v.y * v.z;
    }

    public static class MathAYF
    {
        public static float Average(ReadOnlySpan<int> values)
        {
            int length = values.Length;
            float sum = 0;
            
            foreach (int value in values)
            {
                sum += (float)value / length;
            }

            return sum;
        }
        
        public static float Average(ReadOnlySpan<float> values)
        {
            int length = values.Length;
            float sum = 0;
            
            foreach (float value in values)
            {
                sum += value / length;
            }

            return sum;
        }
        
        public static Vector2 Average(ReadOnlySpan<Vector2> values)
        {
            int length = values.Length;
            Vector2 sum = Vector2.zero;
            
            foreach (Vector2 value in values)
            {
                sum += value / length;
            }

            return sum;
        }
        
        public static Vector3 Average(ReadOnlySpan<Vector3> values)
        {
            int length = values.Length;
            Vector3 sum = Vector3.zero;
            
            foreach (Vector3 value in values)
            {
                sum += value / length;
            }

            return sum;
        }
        
        public static Vector4 Average(ReadOnlySpan<Vector4> values)
        {
            int length = values.Length;
            Vector4 sum = Vector4.zero;
            
            foreach (Vector4 value in values)
            {
                sum += value / length;
            }

            return sum;
        }
    }
}
