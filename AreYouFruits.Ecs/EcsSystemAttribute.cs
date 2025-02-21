using System;

namespace AreYouFruits.Ecs
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class EcsSystemAttribute : Attribute
    {
        
    }
}