using System;
using System.Collections.Generic;
using AreYouFruits.Collections;
using AreYouFruits.Nullability;

namespace AreYouFruits.Events
{
    public sealed class CachedOrderProvider : IOrderProvider<Type>
    {
        private readonly Optional<Dictionary<Type, int>> orders;
        private readonly Optional<int> defaultOrder;

        public CachedOrderProvider(
            Optional<IReadOnlyDictionary<Type, int>> orders,
            Optional<int> defaultOrder
        )
        {
            this.orders = orders.Match(o => o.ToDictionary());
            this.defaultOrder = defaultOrder;
        }
        
        public int GetOrder(Type handlerType)
        {
            if (this.orders.TryGet(out var orders) 
             && orders.TryGetValue(handlerType, out var order))
            {
                return order;
            }

            if (this.defaultOrder.TryGet(out var defaultOrder))
            {
                return defaultOrder;
            }

            throw new ArgumentException($"There is no order for {handlerType} type registered.");
        }
    }
}
