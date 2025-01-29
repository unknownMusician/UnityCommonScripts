using System;
using AreYouFruits.Nullability;
using AreYouFruits.Ordering;

namespace AreYouFruits.Ecs
{
    public sealed class SystemsGraphOrderer
    {
        private readonly GraphOrderer<Type> graphOrderer;

        public SystemsGraphOrderer(GraphOrderer<Type> graphOrderer)
        {
            this.graphOrderer = graphOrderer ?? new();
        }

        public SystemsGraphOrderer() : this(new()) { }
    
        public bool Order<TPrevious, TNext>()
            where TPrevious : ISystem
            where TNext : ISystem
        {
            return graphOrderer.Order(typeof(TPrevious), typeof(TNext));
        }

        public CachedOrderProvider<Type> ToCached(Optional<int> defaultOrder)
        {
            return graphOrderer.ToCached(defaultOrder);
        }
    }
}