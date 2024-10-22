using System;
using System.Collections.Generic;
using System.Linq;
using AreYouFruits.DependencyInjection.Unity.Settings;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AreYouFruits.DependencyInjection.Unity.Editor.Settings
{
    [CustomPropertyDrawer(typeof(Binding))]
    public sealed class BindingDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            rect = EditorGUI.PrefixLabel(rect, label);

            var objectProperty = property.FindPropertyRelative(nameof(Binding.Object));
            var typeNameProperty = property.FindPropertyRelative(nameof(Binding.TypeName));

            var objectRect = rect;
            objectRect.width = (objectRect.width / 2) - 1;

            var typeNameRect = objectRect;
            var typeNamePosition = typeNameRect.position;
            typeNamePosition.x += objectRect.width + 2;
            typeNameRect.position = typeNamePosition;
            
            EditorGUI.ObjectField(objectRect, objectProperty, GUIContent.none);

            var objectReference = objectProperty.objectReferenceValue;

            if (objectReference is null)
            {
                return;
            }

            var types = GetTypes(objectReference).ToList();

            var index = types.IndexOf(Type.GetType(typeNameProperty.stringValue));

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

            var type = value.GetType();

            yield return type;

            foreach (var interfaceType in type.GetInterfaces())
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