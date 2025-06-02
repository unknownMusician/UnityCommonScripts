using System;

namespace AreYouFruits.ToStringGeneration
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public sealed class GenerateToStringAttribute : Attribute { }
}
