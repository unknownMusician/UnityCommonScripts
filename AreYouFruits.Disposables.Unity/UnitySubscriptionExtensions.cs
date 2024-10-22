using UnityEngine.Events;

namespace AreYouFruits.Disposables.Unity
{
    public static class UnitySubscriptionExtensions
    {
        public static ActionDisposable<(UnityEvent, UnityAction)> SubscribeAsDisposable(
            this UnityEvent unityEvent,
            UnityAction handler
        )
        {
            unityEvent.AddListener(handler);

            return ActionDisposable.Create((unityEvent, handler), static i =>
            {
                i.unityEvent.RemoveListener(i.handler);
            });
        }
        
        public static ActionDisposable<(UnityEvent<T>, UnityAction<T>)> SubscribeAsDisposable<T>(
            this UnityEvent<T> unityEvent,
            UnityAction<T> handler
        )
        {
            unityEvent.AddListener(handler);

            return ActionDisposable.Create((unityEvent, handler), static i =>
            {
                i.unityEvent.RemoveListener(i.handler);
            });
        }
        
        public static ActionDisposable<(UnityEvent<T0, T1>, UnityAction<T0, T1>)> SubscribeAsDisposable<T0, T1>(
            this UnityEvent<T0, T1> unityEvent,
            UnityAction<T0, T1> handler
        )
        {
            unityEvent.AddListener(handler);

            return ActionDisposable.Create((unityEvent, handler), static i =>
            {
                i.unityEvent.RemoveListener(i.handler);
            });
        }
        
        public static ActionDisposable<(UnityEvent<T0, T1, T2>, UnityAction<T0, T1, T2>)> SubscribeAsDisposable<T0, T1, T2>(
            this UnityEvent<T0, T1, T2> unityEvent,
            UnityAction<T0, T1, T2> handler
        )
        {
            unityEvent.AddListener(handler);

            return ActionDisposable.Create((unityEvent, handler), static i =>
            {
                i.unityEvent.RemoveListener(i.handler);
            });
        }
        
        public static ActionDisposable<(UnityEvent<T0, T1, T2, T3>, UnityAction<T0, T1, T2, T3>)> SubscribeAsDisposable<T0, T1, T2, T3>(
            this UnityEvent<T0, T1, T2, T3> unityEvent,
            UnityAction<T0, T1, T2, T3> handler
        )
        {
            unityEvent.AddListener(handler);

            return ActionDisposable.Create((unityEvent, handler), static i =>
            {
                i.unityEvent.RemoveListener(i.handler);
            });
        }
    }
}
