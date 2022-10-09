using System;
using AreYouFruits.Common.InspectorValidation;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEditor;

namespace AreYouFruits.Common.ComponentGeneration
{
    [Serializable]
    public struct SerializedInterface<TInterface>
        where TInterface : class
    {
    #nullable disable
        [SerializeField] private Object _object;
    #nullable enable

        public SerializedInterface(TInterface value)
        {
            _object = value as Object;
        }

        public TInterface Interface => _object as TInterface ?? throw new BehaviourNotInitializedException();
        public Object AsObject => _object;

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
