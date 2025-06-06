﻿using System;
using System.Collections.Generic;
using System.Linq;
using AreYouFruits.Ordering;

namespace AreYouFruits.Ecs
{
    public sealed class SystemScheduler
    {
        private readonly Action<Exception> exceptionLogger;
        private readonly ISystem[] systems;
        
        private readonly ResourcesHolder resources;
        private readonly EventsHolder events;
        
        public SystemScheduler(
            Action<Exception> exceptionLogger,
            IOrderProvider<Type> orderer,
            IEnumerable<ISystem> systems,
            ResourcesHolder resources,
            EventsHolder events
        )
        {
            this.exceptionLogger = exceptionLogger;
            this.resources = resources;
            this.events = events;
            this.systems = systems.ToArray();
            
            Array.Sort(this.systems, new SystemOrderComparer(orderer));
        }

        public void ExecuteIteration(bool shouldPreserveEvents = false)
        {
            var ctx = new SystemContext
            {
                Resources = resources,
                Events = events,
            };

            foreach (var system in systems)
            {
                try
                {
                    system.Execute(ctx);
                }
                catch (Exception exception)
                {
                    exceptionLogger(exception);
                }
            }

            if (!shouldPreserveEvents)
            {
                events.Clear();
            }
        }
    }
}