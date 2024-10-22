using System;

namespace AreYouFruits.Events
{
    public readonly struct GraphOrderingHelper<TEvent>
        where TEvent : IEvent
    {
        private readonly GraphOrderer orderer;

        public GraphOrderingHelper(GraphOrderer orderer)
        {
            this.orderer = orderer;
        }

        public bool Order<TPrevious, TNext>()
            where TPrevious : IEventHandler<TEvent>
            where TNext : IEventHandler<TEvent>
        {
            return orderer.Order(typeof(TPrevious), typeof(TNext));
        }
    }
}