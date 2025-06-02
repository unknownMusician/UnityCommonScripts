using System;

namespace AreYouFruits.ConstructorGeneration
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class GenerateConstructorAttribute : Attribute { }
}