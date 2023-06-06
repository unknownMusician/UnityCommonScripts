using System;
using Object = UnityEngine.Object;

namespace AreYouFruits.Common.Unity.DependencyInjection.Settings
{
    [Serializable]
    public struct Binding
    {
        public Object Object;
        public string TypeName;
    }
}