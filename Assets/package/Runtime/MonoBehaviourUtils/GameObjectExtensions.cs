using UnityEngine;

namespace AreYouFruits.MonoBehaviourUtils.Unity
{
    public static class GameObjectExtensions
    {
        public static bool Exists(this Object obj)
        {
            return obj != null;
        }
    }
}
