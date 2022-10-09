using System;
using System.Diagnostics;

namespace AreYouFruits.Common.Assertions
{
    public static class Assertion
    {
        private const string DirectiveName = "ASSERTIONS_ENABLED";

        [Conditional(DirectiveName)]
        public static void AssertNotNull(this object? nullable, string? name = "")
        {
            if (nullable != null)
            {
                return;
            }

            string valueName = string.IsNullOrEmpty(name) ? "value" : name!;

            throw new ArgumentNullException($"{valueName} should not be null");
        }

        [Conditional(DirectiveName)]
        public static void ThrowIf(bool condition, Func<Exception> exceptionProvider)
        {
            if (condition)
            {
                throw exceptionProvider();
            }
        }

        [Conditional(DirectiveName)]
        public static void ThrowIf<TException>(bool condition)
            where TException : Exception, new()
        {
            if (condition)
            {
                throw new TException();
            }
        }

        [Conditional(DirectiveName)]
        public static void ThrowIf(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }
    }
}
