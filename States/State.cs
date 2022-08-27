using System;
using System.Collections.Generic;
using AreYouFruits.Common.Collections;

namespace AreYouFruits.Common.States
{
    public sealed class State<TActionsName> : IDisposable
        where TActionsName : Enum
    {
        private readonly Dictionary<TActionsName, Delegate> _actions = new Dictionary<TActionsName, Delegate>();

        public State<TActionsName> Register<TDelegate>(TActionsName actionName, TDelegate action)
            where TDelegate : Delegate
        {
            _actions[actionName] = action;

            return this;
        }

        public State<TActionsName> Register<TDelegate>(params (TActionsName actionName, TDelegate action)[] pairs)
            where TDelegate : Delegate
        {
            pairs.Foreach(pair => Register(pair.actionName, pair.action));

            return this;
        }

        public TDelegate Get<TDelegate>(TActionsName actionName)
            where TDelegate : Delegate => (TDelegate)_actions[actionName];

        public void Dispose() => _actions.Clear();
    }
}
