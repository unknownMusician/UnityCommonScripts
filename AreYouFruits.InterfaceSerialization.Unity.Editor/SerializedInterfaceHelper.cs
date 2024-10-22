using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AreYouFruits.InterfaceSerialization.Unity.Editor
{
    public static class SerializedInterfaceHelper
    {
        [MenuItem("Are You Fruits?/Try fix all Inspector dependencies")]
        public static void TryFixInspectorDependencies()
        {
            IEnumerable<MonoBehaviour> components = Object.FindObjectsOfType<MonoBehaviour>();

            foreach (var behaviour in components)
            {
                var type = behaviour.GetType();

                var fields = type
                    .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(field => field.IsPublic || (field.GetCustomAttribute<SerializeField>() != null))
                    .Where(field => typeof(SerializedInterface<>).IsAssignableFrom(field.FieldType));

                foreach (var field in fields)
                {
                    var serializedInterface = field.GetValue(behaviour)!;

                    var serializedInterfaceType = serializedInterface.GetType();

                    var serializedInterfaceTypeObjectField = serializedInterfaceType.GetField(
                        "_object",
                        BindingFlags.Instance | BindingFlags.NonPublic
                    )!;

                    var foundReference = TryGetReferenceFromScene(
                        serializedInterfaceType.GenericTypeArguments[0],
                        behaviour,
                        field
                    );

                    if (foundReference == null)
                    {
                        continue;
                    }

                    var oldObjectValue =
                        (Object)serializedInterfaceTypeObjectField.GetValue(serializedInterface);

                    if (oldObjectValue == null)
                    {
                        serializedInterfaceTypeObjectField.SetValue(serializedInterface, foundReference);

                        field.SetValue(behaviour, serializedInterface);
                    }
                }
            }
        }

        private static Component TryGetReferenceFromScene(
            Type type, Object inspectedObject = null, FieldInfo inspectedField = null
        )
        {
            var references = Object.FindObjectsOfType<Component>().Where(type.IsInstanceOfType).ToArray();

            if (references.Length > 1)
            {
                Debug.LogWarning(
                    $"There are more than one candidate for {inspectedField?.Name} in {inspectedObject?.name}",
                    inspectedObject
                );
            }

            return references.Length == 1 ? references.First() : null;
        }
    }
}
