using System;

namespace AreYouFruits.Ecs
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class IntentionallyUnusedAttribute : Attribute { }
}