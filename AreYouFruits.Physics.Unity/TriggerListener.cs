using System;
using UnityEngine;

namespace AreYouFruits.Common.Physics
{
    public sealed class TriggerListener : MonoBehaviour
    {
        public event Action<Collider> OnEnter;
        public event Action<Collider> OnExit;
        
        private void OnTriggerEnter(Collider collider)
        {
            OnEnter?.Invoke(collider);
        }

        private void OnTriggerExit(Collider collider)
        {
            OnExit?.Invoke(collider);
        }
    }
}

