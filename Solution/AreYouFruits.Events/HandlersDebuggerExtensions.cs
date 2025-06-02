using System;
using AreYouFruits.Nullability;

namespace AreYouFruits.Events
{
    public static class HandlersDebuggerExtensions
    {
        public static void InvokeHandlerStarting(this Optional<IHandlersDebugger> handlersDebugger, Type handlerType)
        {
            if (handlersDebugger.TryGet(out var debugger))
            {
                debugger.HandleHandlerStarting(handlerType);
            }
        }
        
        public static void InvokeHandlerEnded(this Optional<IHandlersDebugger> handlersDebugger, Type handlerType)
        {
            if (handlersDebugger.TryGet(out var debugger))
            {
                debugger.HandleHandlerEnded(handlerType);
            }
        }
    }
}
