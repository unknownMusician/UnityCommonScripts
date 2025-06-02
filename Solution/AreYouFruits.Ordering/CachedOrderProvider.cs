using System;
using System.Collections.Generic;
using AreYouFruits.Collections;
using AreYouFruits.Nullability;

namespace AreYouFruits.Ordering
{
    public static class CachedOrderProvider
    {
        public static CachedOrderProvider<T> From<T>(
            Optional<IReadOnlyDictionary<T, int>> orders,
            Optional<int> defaultOrder
        )
        {
            return new CachedOrderProvider<T>(orders, defaultOrder);
        }
    }
    
    public sealed class CachedOrderProvider<T> : IOrderProvider<T>
    {
        private readonly Optional<Dictionary<T, int>> orders;
        private readonly Optional<int> defaultOrder;

        public CachedOrderProvider(
            Optional<IReadOnlyDictionary<T, int>> orders,
            Optional<int> defaultOrder
        )
        {
            this.orders = orders.Match(o => o.ToDictionary());
            this.defaultOrder = defaultOrder;
        }
        
        public int GetOrder(T value)
        {
            if (this.orders.TryGet(out var orders) 
             && orders.TryGetValue(value, out var order))
            {
                return order;
            }

            if (this.defaultOrder.TryGet(out var defaultOrder))
            {
                return defaultOrder;
            }

            throw new ArgumentOutOfRangeException(nameof(value), value, $"There is no order for {value} registered.");
        }
    }
}
