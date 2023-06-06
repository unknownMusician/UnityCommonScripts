using System;
using System.Collections.Generic;

namespace AreYouFruits.Common.Observable
{
    public sealed class Observable<T> : IReadOnlyObservable<T>
    {
        public event Action OnChange;

        private T value;

        public T Value
        {
            get => value;
            set
            {
                if (EqualityComparer<T>.Default.Equals(this.value, value))
                {
                    return;
                }

                this.value = value;
                OnChange?.Invoke();
            }
        }

        public Observable(T value)
        {
            this.value = value;
        }
    }
}