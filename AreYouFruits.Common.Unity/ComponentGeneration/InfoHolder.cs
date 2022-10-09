using UnityEngine;

namespace AreYouFruits.Common.ComponentGeneration
{
    public abstract class InfoHolder<TInfo> : ScriptableObject, IComponent<TInfo>
    {
    #nullable disable
        [SerializeField] protected TInfo Info;
    #nullable enable

        public TInfo HeldItem => Info;
    }
}
