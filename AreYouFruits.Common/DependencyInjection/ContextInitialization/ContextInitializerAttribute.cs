using System;

namespace AreYouFruits.DependencyInjection.ContextInitialization
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ContextInitializerAttribute : Attribute { }
}