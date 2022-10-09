using System;

namespace AreYouFruits.Common.ComponentGeneration
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class HasComponentAttribute : Attribute
    {
        public readonly bool HasInterfaceAlso;
        
        public HasComponentAttribute(bool hasInterfaceAlso)
        {
            HasInterfaceAlso = hasInterfaceAlso;
        }
    }
}
