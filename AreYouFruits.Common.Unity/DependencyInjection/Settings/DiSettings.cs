using UnityEngine;

namespace AreYouFruits.Common.Unity.DependencyInjection.Settings
{
    public sealed class DiSettings : ScriptableObject
    {
        [field: SerializeField] public Binding[] Bindings { get; set; }
    }
}