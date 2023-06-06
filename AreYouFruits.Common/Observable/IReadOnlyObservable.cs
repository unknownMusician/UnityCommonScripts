using System;

namespace AreYouFruits.Common.Observable
{
    public interface IReadOnlyObservable<out T>
    {
        public event Action OnChange;

        public T Value { get; }
    }
}