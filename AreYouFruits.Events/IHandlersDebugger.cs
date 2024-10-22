using System;

namespace AreYouFruits.Events
{
    public interface IHandlersDebugger
    {
        public void HandleHandlerStarting(Type handlerType);
        public void HandleHandlerEnded(Type handlerType);
    }
}
