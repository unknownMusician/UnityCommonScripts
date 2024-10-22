using System;
using System.Collections.Generic;

namespace AreYouFruits.Disposables
{
    public sealed class DelegatesHolder<TDelegate>
        where TDelegate : Delegate
    {
        private readonly List<TDelegate> delegates = new();

        public IReadOnlyCollection<TDelegate> Delegates => delegates;
        
        public ActionDisposable<(List<TDelegate>, TDelegate)> Subscribe(TDelegate @delegate)
        {
            delegates.Add(@delegate);
            return ActionDisposable.Create((delegates, @delegate), static i => i.delegates.Remove(i.@delegate));
        }
    }
}
