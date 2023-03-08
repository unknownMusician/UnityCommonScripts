using System;
using Object = UnityEngine.Object;

namespace Starfish.TempDi.Settings
{
    [Serializable]
    public struct Binding
    {
        public Object Object;
        public string TypeName;
    }
}