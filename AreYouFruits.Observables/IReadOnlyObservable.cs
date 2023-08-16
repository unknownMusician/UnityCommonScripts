using System;

namespace AreYouFruits.Observables
{
    public interface IReadOnlyObservable<out T>
    {
        public event Action OnChange;

        public T Value { get; }
    }
}