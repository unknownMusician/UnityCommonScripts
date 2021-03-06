using System;
using UnityEngine;

namespace AreYouFruits.Common.ComponentGeneration
{
    public abstract class AbstractComponent<T> : MonoBehaviour, IComponent<T>
        where T : class
    {
        private T? _heldItem;
        private bool _isStartedInitialization = false;

        public T HeldItem
        {
            get
            {
                if (_heldItem != null)
                {
                    return _heldItem;
                }

                if (_isStartedInitialization)
                {
                    throw new RecursiveInitializationException();
                }

                _isStartedInitialization = true;
                _heldItem = Create();

                return _heldItem;
            }
        }

        protected virtual void Start()
        {
            _ = HeldItem;
        }

        protected virtual void OnDestroy()
        {
            if (HeldItem is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        protected abstract T Create();
    }
}
