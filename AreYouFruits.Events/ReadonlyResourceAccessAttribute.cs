using System;

namespace AreYouFruits.Events
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ReadonlyResourceAccessAttribute : Attribute { }
}