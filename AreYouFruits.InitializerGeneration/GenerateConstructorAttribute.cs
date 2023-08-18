using System;

namespace AreYouFruits.InitializerGeneration
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class GenerateInitializerAttribute : Attribute { }
}