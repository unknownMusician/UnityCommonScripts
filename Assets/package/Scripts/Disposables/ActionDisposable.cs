using System;

namespace AreYouFruits.Disposables
{
    public struct ActionDisposable<TParam> : IDisposable
    {
        private readonly TParam parameter;
        private Action<TParam> disposer;
        
        public readonly bool IsDisposed => disposer is null;

        public ActionDisposable(TParam parameter, Action<TParam> disposer)
        {
            this.parameter = parameter;
            this.disposer = disposer;
        }

        public void Dispose()
        {
            if (disposer is null)
            {
                return;
            }

            disposer(parameter);
            disposer = null;
        }
    }
    
    public struct ActionDisposable : IDisposable
    {
        private Action disposer;
        
        public readonly bool IsDisposed => disposer is null;

        public ActionDisposable(Action disposer)
        {
            this.disposer = disposer;
        }

        public void Dispose()
        {
            if (disposer is null)
            {
                return;
            }

            disposer();
            disposer = null;
        }

        public static ActionDisposable Create(Action disposer)
        {
            return new ActionDisposable(disposer);
        }

        public static ActionDisposable<TParam> Create<TParam>(TParam parameter, Action<TParam> disposer)
        {
            return new ActionDisposable<TParam>(parameter, disposer);
        }
    }
}
