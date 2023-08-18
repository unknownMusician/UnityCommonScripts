using System;

namespace AreYouFruits.InitializerGeneration
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public sealed class GeneratedInitializerNameAttribute : Attribute
    {
        public string Name { get; }

        public GeneratedInitializerNameAttribute(string name)
        {
            Name = name;
        }
    }
}
