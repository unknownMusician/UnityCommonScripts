using System;
using AreYouFruits.Ordering;

namespace AreYouFruits.Ecs
{
    public readonly struct SystemsGroupGraphOrdererOrderGroupHelper
    {
        private readonly GroupGraphOrdererOrderGroupHelper<Type> helper;

        public SystemsGroupGraphOrdererOrderGroupHelper(GroupGraphOrdererOrderGroupHelper<Type> helper)
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