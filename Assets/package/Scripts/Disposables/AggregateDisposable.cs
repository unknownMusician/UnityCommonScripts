using System;
using System.Collections.Generic;

namespace AreYouFruits.Disposables
{
    public sealed class AggregateDisposable : IDisposable
    {
        private readonly object locker = new();
        private List<IDisposable> disposables = new();
        private bool isDisposingCurrentCollection;

        public void Add(IDisposable disposable)
        {
            lock (locker)
            {
                if (isDisposingCurrentCollection)
                {
                    disposables = new();
                    isDisposingCurrentCollection = false;
                }
                disposables.Add(disposable);
            }
        }

        public void Dispose()
        {
            List<IDisposable> lastDisposables;

            lock (locker)
            {
                isDisposingCurrentCollection = true;
                lastDisposables = disposables;
            }

            try
            {
                foreach (var disposable in lastDisposables)
                {
                    disposable.Dispose();
                }
            }
            finally
            {
                lock (locker)
                {
                    if (lastDisposables == disposables)
                    {
                        isDisposingCurrentCollection = false;
                    }
                }
            }
        }
    }
}
