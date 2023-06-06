using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace AreYouFruits.Common.Assertions
{
    public static class Assertion
    {
        private const string DirectiveName = "ASSERTIONS_ENABLED";

        [Conditional(DirectiveName)]
        public static void ThrowIfNull([MaybeNull] this object nullable)
        {
            ThrowIf(nullable is null, () => new ArgumentNullException());
            ThrowIf<ArgumentNullException>(nullable is null);
            if (nullable is null)
            {
                throw new ArgumentNullException();
            }
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
        public static void ThrowIf(bool condition, Exception exception)
        {
            if (condition)
            {
                throw exception;
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
