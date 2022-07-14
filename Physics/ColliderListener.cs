using System;
using UnityEngine;

namespace AreYouFruits.Common.Physics
{
    public sealed class ColliderListener : MonoBehaviour
    {
        public event Action<Collision>? OnEnter;
        public event Action<Collision>? OnExit;

        private void OnCollisionEnter(Collision collision)
        {
            OnEnter?.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            OnExit?.Invoke(collision);
        }
    }
}
