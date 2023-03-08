using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Starfish.TempDi.Settings
{
    [CustomPropertyDrawer(typeof(Binding))]
    public sealed class BindingDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            rect = EditorGUI.PrefixLabel(rect, label);

            SerializedProperty objectProperty = property.FindPropertyRelative(nameof(Binding.Object));
            SerializedProperty typeNameProperty = property.FindPropertyRelative(nameof(Binding.TypeName));

            Rect objectRect = rect;
            objectRect.width = (objectRect.width / 2) - 1;

            Rect typeNameRect = objectRect;
            Vector2 typeNamePosition = typeNameRect.position;
            typeNamePosition.x += objectRect.width + 2;
            typeNameRect.position = typeNamePosition;
            
            EditorGUI.ObjectField(objectRect, objectProperty, GUIContent.none);

            Object objectReference = objectProperty.objectReferenceValue;

            if (objectReference is null)
            {
                return;
            }

            List<Type> types = GetTypes(objectReference);

            int index = types.IndexOf(Type.GetType(typeNameProperty.stringValue));

            if (index is -1)
            {
                index = 0;
            }

            index = EditorGUI.Popup(typeNameRect, index, types.Select(type => type.Name).ToArray());
            typeNameProperty.stringValue = types[index].AssemblyQualifiedName;
        }

        private List<Type> GetTypes(object value)
        {
            var result = new List<Type>();

            if (value is null)
            {
                return result;
            }

            Type type = value.GetType();

            while (true)
            {
                result.Add(type);

                if (type == typeof(object))
                {
                    break;
                }

                type = type.BaseType;
            }

            return result;
        }
    }
}