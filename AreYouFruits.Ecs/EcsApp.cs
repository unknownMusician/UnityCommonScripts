using System;
using System.Collections.Generic;
using System.Linq;
using AreYouFruits.Ordering;

namespace AreYouFruits.Ecs
{
    public sealed class EcsApp
    {
        private readonly ISystem[] systems;

        public ResourcesHolder Resources { get; } = new();
        public EventsHolder Events { get; } = new();

        public EcsApp(IOrderProvider<Type> orderer, IEnumerable<ISystem> systems)
        {
            this.systems = systems.ToArray();
            Array.Sort(this.systems, new SystemOrderComparer(orderer));
        }

        public void ExecuteIteration()
        {
            Events.Clear();

            foreach (var system in systems)
            {
                var ctx = new SystemContext
                {
                    Resources = Resources,
                    Events = Events,
                };

                system.Execute(ctx);
            }
        }
    }
}