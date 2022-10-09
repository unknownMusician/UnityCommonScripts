using System;
using UnityEditor;
using UnityEngine;

namespace AreYouFruits.Common.InspectorValidation
{
    [CustomPropertyDrawer(typeof(ContainsComponentAttribute))]
    public sealed class ContainsComponentAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.type != "PPtr<$GameObject>")
            {
                Debug.LogError(
                    $"{nameof(ContainsComponentAttribute)} can only be used with field of type UnityEngine.GameObject.");

                return;
            }

            GameObject newObject = (GameObject)EditorGUI.ObjectField(position, label, property.objectReferenceValue,
                typeof(GameObject), true);

            if (newObject == null)
            {
                return;
            }

            ContainsComponentAttribute containsComponentAttribute = (ContainsComponentAttribute)attribute;

            foreach (Type componentType in containsComponentAttribute.ComponentTypes)
            {
                if (!newObject.TryGetComponent(componentType, out _))
                {
                    Debug.LogWarning($"Only GameObjects with component {componentType} allowed.");

                    return;
                }
            }

            property.objectReferenceValue = newObject;
        }
    }
}