using System;
using System.Collections.Generic;
using AreYouFruits.Ordering;

namespace AreYouFruits.Ecs
{
    public sealed class SystemOrderComparer : IComparer<ISystem>
    {
        private IOrderProvider<Type> orderer;

        public SystemOrderComparer(IOrderProvider<Type> orderer)
        {
            this.orderer = orderer;
        }

        public int Compare(ISystem x, ISystem y)
        {
            if (x is null && y is null)
            {
                return 0;
            }

            if (x is null)
            {
                return -1;
            }

            if (y is null)
            {
                return 1;
            }
        
            return orderer.GetOrder(x.GetType()).CompareTo(orderer.GetOrder(y.GetType()));
        }
    }
}