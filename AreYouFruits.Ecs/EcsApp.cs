using System;
using System.Collections.Generic;
using AreYouFruits.Nullability;
using AreYouFruits.Ordering;

namespace AreYouFruits.Ecs
{
    public sealed class EcsApp
    {
        private readonly Dictionary<object, SystemScheduler> schedulers = new();

        public ResourcesHolder Resources { get; } = new();
        public EventsHolder Events { get; } = new();

        public Optional<SystemScheduler> CreateScheduler(
            object schedule,
            IOrderProvider<Type> orderer,
            IEnumerable<ISystem> systems
        )
        {
            if (schedulers.ContainsKey(schedule))
            {
                return Optional.None();
            }
            
            var scheduler = new SystemScheduler(orderer, systems, Resources, Events);
            schedulers.Add(schedule, scheduler);
            
            return scheduler;
        }

        public Optional<SystemScheduler> GetScheduler(object schedule)
        {
            if (!schedulers.TryGetValue(schedule, out var scheduler))
            {
                return Optional.None();
            }

            return scheduler;
        }
    }
}