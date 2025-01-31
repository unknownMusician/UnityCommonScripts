using System;
using System.Collections.Generic;
using System.Linq;
using AreYouFruits.Ordering;

namespace AreYouFruits.Ecs
{
    public sealed class SystemScheduler
    {
        private readonly ISystem[] systems;
        
        private readonly ResourcesHolder resources;
        private readonly EventsHolder events;
        
        public SystemScheduler(
            IOrderProvider<Type> orderer,
            IEnumerable<ISystem> systems,
            ResourcesHolder resources,
            EventsHolder events
        )
        {
            this.resources = resources;
            this.events = events;
            this.systems = systems.ToArray();
            
            Array.Sort(this.systems, new SystemOrderComparer(orderer));
        }

        public void ExecuteIteration()
        {
            var ctx = new SystemContext
            {
                Resources = resources,
                Events = events,
            };

            foreach (var system in systems)
            {
                system.Execute(ctx);
            }

            events.Clear();
        }
    }
}