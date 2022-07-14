using System;
using UnityEngine;

namespace AreYouFruits.Common
{
    [Serializable]
    public class SingleInit<T>
    {
        [SerializeField] private T? _item;
        
        public bool IsInitialized { get; private set; }
        
        public T? Item
        {
            get => _item;
            set
            {
                _item = IsInitialized ? throw new InvalidOperationException() : value;
                IsInitialized = true;
            }
        }
    }
}
