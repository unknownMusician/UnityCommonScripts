using System;
using System.Collections.Generic;

namespace AreYouFruits.Assertions
{
    public static class Assertion
    {
        public static T ExpectLike<T>(this T value, Func<T, bool> predicate)
        {
            if (!predicate(value))
            {
                throw new ArgumentOutOfRangeException($"Value failed the predicate and is {value.ToString()}.");
            }

            return value;
        }
        
        public static T Expect<T>(this T value, T expectedValue)
        {
            if (!EqualityComparer<T>.Default.Equals(value, expectedValue))
            {
                throw new ArgumentOutOfRangeException($"Value should be {expectedValue.ToString()}, but is {value.ToString()}.");
            }

            return value;
        }

        public static T ExpectNot<T>(this T value, T unexpectedValue)
        {
            if (EqualityComparer<T>.Default.Equals(value, unexpectedValue))
            {
                throw new ArgumentOutOfRangeException($"Value should not be {unexpectedValue.ToString()}, but it is.");
            }

            return value;
        }
    }
}
