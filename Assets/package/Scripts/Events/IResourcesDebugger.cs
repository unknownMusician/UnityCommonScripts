using System;

namespace AreYouFruits.Events
{
    public interface IResourcesDebugger
    {
        public void HandleResourceAccessed(Type resourceType, Type resourceAccessType, bool isReadonly);
    }
}