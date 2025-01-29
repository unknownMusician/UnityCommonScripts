using System;
using AreYouFruits.Ordering;

namespace AreYouFruits.Ecs
{
    public readonly struct SystemsGroupGraphOrdererOrderHandlerHelper
    {
        private readonly GroupGraphOrdererOrderHandlerHelper<Type> helper;

        public SystemsGroupGraphOrdererOrderHandlerHelper(GroupGraphOrdererOrderHandlerHelper<Type> helper)
        {
            this.helper = helper;
        }

        public void Before<TNext>()
            where TNext : ISystem
        {
            helper.Before(typeof(TNext));
        }

        public void Before(SystemGroupId nextGroup)
        {
            helper.Before(nextGroup.id);
        }
    }
}