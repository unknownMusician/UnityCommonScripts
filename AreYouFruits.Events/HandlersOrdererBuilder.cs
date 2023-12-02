using System;
using System.Collections.Generic;

namespace AreYouFruits.EventBus
{
    public sealed class HandlersOrdererBuilder
    {
        private readonly Dictionary<Type, Dictionary<long, Type>> messageOrders = new();
        private readonly Dictionary<long, Type> defaultOrders = new();

        public bool SetOrder(long order, Type callerType, Type messageType)
        {
            if (!messageOrders.TryGetValue(messageType, out var orders))
            {
                orders = new();
                messageOrders[messageType] = orders;
            }

            return orders.TryAdd(order, callerType);
        }

        public bool SetOrder(long order, Type callerType)
        {
            return defaultOrders.TryAdd(order, callerType);
        }

        public HandlersOrderer Build()
        {
            return HandlersOrderer.FromBuilder(messageOrders, defaultOrders);
        }
    }
}
