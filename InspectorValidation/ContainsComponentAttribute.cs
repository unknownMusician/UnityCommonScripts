#if UNITY_2021_3_8

using System;
using UnityEngine;

namespace AreYouFruits.Common.InspectorValidation
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ContainsComponentAttribute : PropertyAttribute
    {
        public readonly Type[] ComponentTypes;

        public ContainsComponentAttribute(Type componentType, params Type[] otherComponentTypes)
        {
            if (otherComponentTypes.Length == 0)
            {
                ComponentTypes = new[] { componentType };
                return;
            }

            var types = new Type[otherComponentTypes.Length + 1];

            types[0] = componentType;

            Array.Copy(otherComponentTypes, 0, types, 1, otherComponentTypes.Length);
            ComponentTypes = types;
        }
    }
}

#endif