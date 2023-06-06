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

            List<Type> types = GetTypes(objectReference).ToList();

            int index = types.IndexOf(Type.GetType(typeNameProperty.stringValue));

            if (index is -1)
            {
                index = 0;
            }

            index = EditorGUI.Popup(typeNameRect, index, types.Select(GetDisplayedName).ToArray());
            typeNameProperty.stringValue = types[index].AssemblyQualifiedName;
        }

        private static string GetDisplayedName(Type type)
        {
            if (type.Namespace == nameof(System))
            {
                return type.FullName;
            }
            
            return type.Name;
        }

        private static IEnumerable<Type> GetTypes(object value)
        {
            if (value is null)
            {
                yield break;
            }

            Type type = value.GetType();

            yield return type;

            foreach (Type interfaceType in type.GetInterfaces())
            {
                yield return interfaceType;
            }

            type = type.BaseType;

            while (type != null)
            {
                yield return type;
                
                type = type.BaseType;
            }
        }
    }
}