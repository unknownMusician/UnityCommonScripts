using System;
using Object = UnityEngine.Object;

namespace AreYouFruits.DependencyInjection.Unity.Settings
{
    [Serializable]
    public struct Binding
    {
        public Object Object;
        public string TypeName;
    }
}