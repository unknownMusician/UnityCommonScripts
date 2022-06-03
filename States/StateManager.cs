using System;
using System.Collections.Generic;
using AreYouFruits.Common.Collections.InterfaceExtensions;

namespace AreYouFruits.Common.States
{
    public abstract class StateManager<TStateName>
        where TStateName : struct, Enum
    {
        internal Action<TStateName>? OnStateChangeEvent;

        public event Action<TStateName> OnStateChange
        {
            add
            {
                OnStateChangeEvent += value;
                value(ActiveName);
            }
            remove => OnStateChangeEvent -= value;
        }

        protected internal TStateName ActiveName { get; protected set; }
    }

    public abstract class StateManager<TStateName, TActionsName> : StateManager<TStateName>, IDisposable
        where TStateName : struct, Enum
        where TActionsName : struct, Enum
    {
        protected Dictionary<TStateName, State<TActionsName>> _states =
            new Dictionary<TStateName, State<TActionsName>>();


        public State<TActionsName> Active => _states[ActiveName];
        public readonly StateHook<TStateName> Hook;

        public StateManager() => Hook = new StateHook<TStateName>(this);

        public State<TActionsName> Register(TStateName stateName)
        {
            _states.Remove(stateName);

            return _states[stateName] = new State<TActionsName>();
        }

        protected void TryChange(TStateName stateName)
        {
            if (!ActiveName.Equals(stateName))
            {
                ActiveName = stateName;
                OnStateChangeEvent?.Invoke(stateName);
            }
        }

        public virtual void Dispose()
        {
            foreach ((_, State<TActionsName> state) in _states)
            {
                state.Dispose();
            }

            OnStateChangeEvent = null;
            _states.Clear();
        }
    }

    public sealed class ChangeableStateManager<TStateName, TActionsName> : StateManager<TStateName, TActionsName>
        where TStateName : struct, Enum
        where TActionsName : struct, Enum
    {
        public new void TryChange(TStateName stateName) => base.TryChange(stateName);
    }

    public sealed class HookableStateManager<TStateName, TActionsName> : StateManager<TStateName, TActionsName>
        where TStateName : struct, Enum
        where TActionsName : struct, Enum
    {
        private readonly List<StateManager<TStateName>> _hookedManagers = new List<StateManager<TStateName>>();

        public void HookTo(StateHook<TStateName> hook) => HookTo(hook.StateManager);

        public void HookTo(StateManager<TStateName> originalStateManager)
        {
            originalStateManager.OnStateChange += TryChange;
            _hookedManagers.Add(originalStateManager);
        }

        public override void Dispose()
        {
            _hookedManagers.Foreach(manager => manager.OnStateChange -= TryChange);
            _hookedManagers.Clear();
            base.Dispose();
        }
    }

    public class StateHook<TStateName>
        where TStateName : struct, Enum
    {
        internal StateManager<TStateName> StateManager;

        internal StateHook(StateManager<TStateName> stateManager) => StateManager = stateManager;
    }
}
