using UnityEngine;

namespace AreYouFruits.DependencyInjection.Unity.Settings
{
    public sealed class DiSettings : ScriptableObject
    {
        [field: SerializeField] public Binding[] Bindings { get; set; }
    }
}