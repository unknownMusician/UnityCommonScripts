using System;
using System.Collections.Generic;

namespace AreYouFruits.EventBus
{
    public sealed class HandlersOrderer
    {
        private readonly Dictionary<Type, Dictionary<Type, long>> orders;
        private readonly Dictionary<Type, long> defaultOrders;

        private HandlersOrderer(Dictionary<Type, Dictionary<Type, long>> orders, Dictionary<Type, long> defaultOrders)
        {
            this.orders = orders;
            this.defaultOrders = defaultOrders;
        }

        public static HandlersOrderer FromBuilder(
            IReadOnlyDictionary<Type, Dictionary<long, Type>> messageOrders,
            IReadOnlyDictionary<long, Type> defaultOrders
        )
        {
            var finalOrders = new Dictionary<Type, Dictionary<Type, long>>();
            var finalDefaultOrders = new Dictionary<Type, long>();

            foreach ((var messageType, var orders) in messageOrders)
            {
                var newOrders = new Dictionary<Type, long>();

                foreach ((long order, var callerType) in orders)
                {
                    newOrders.Add(callerType, order);
                }

                finalOrders.Add(messageType, newOrders);
            }

            foreach ((long order, var callerType) in defaultOrders)
            {
                finalDefaultOrders.Add(callerType, order);
            }

            return new HandlersOrderer(finalOrders, finalDefaultOrders);
        }
        
        public long GetOrder(Type callerType, Type messageType)
        {
            if (orders.TryGetValue(messageType, out var messageOrders)
            && messageOrders. TryGetValue(callerType, out var order))
            {
                return order;
            }

            if (defaultOrders.TryGetValue(callerType, out order))
            {
                return order;
            }

            throw new ArgumentException($"There is no order for {callerType} type registered.");
        }
    }
}
