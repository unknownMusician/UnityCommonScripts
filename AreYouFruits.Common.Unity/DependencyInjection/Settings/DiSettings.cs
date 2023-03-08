using UnityEngine;

namespace Starfish.TempDi.Settings
{
    public sealed class DiSettings : ScriptableObject
    {
        #nullable disable
        [SerializeField] private Binding[] bindings;
        #nullable enable
        
        public Binding[] Bindings => bindings;
    }
}