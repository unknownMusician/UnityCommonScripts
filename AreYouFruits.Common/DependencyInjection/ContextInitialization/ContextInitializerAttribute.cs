using System;

namespace AreYouFruits.Common.DependencyInjection.ContextInitialization
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ContextInitializerAttribute : PreserveAttribute
    {
        public object Key { get; }
        public ContextType ContextType { get; }

        public ContextInitializerAttribute(ContextType contextType = ContextType.Runtime, object key = null)
        {
            Key = key;
            ContextType = contextType;
        }
    }
}