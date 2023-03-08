using System;

namespace AreYouFruits.Common.Observable
{
    public sealed class Observable<T> : IReadOnlyObservable<T>
    {
        public event Action? OnChange;

        private T value = default!;

        public T Value
        {
            get => value;
            set
            {
                if (object.Equals(this.value, value))
                {
                    return;
                }

                this.value = value;
                OnChange?.Invoke();
            }
        }
    }
}