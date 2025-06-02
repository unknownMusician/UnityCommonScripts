using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AreYouFruits.InterfaceSerialization.Unity
{
    [Serializable]
    public struct SerializedInterface<TInterface>
        where TInterface : class
    {
        [SerializeField] private Object _object;

        public SerializedInterface(TInterface value)
        {
            _object = value as Object;
        }

        public TInterface Interface => _object as TInterface ?? throw new NullReferenceException();
        
        // ReSharper disable once Unity.NoNullCoalescing
        public Object AsObject => _object ?? throw new NullReferenceException();

        public static implicit operator TInterface(SerializedInterface<TInterface> serializedInterface)
        {
            return serializedInterface.Interface;
        }

        public static implicit operator SerializedInterface<TInterface>(TInterface @interface)
        {
            return new SerializedInterface<TInterface>(@interface);
        }
    }
}
