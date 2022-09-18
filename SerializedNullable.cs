#if UNITY_2021_3

using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AreYouFruits.Common
{
    [Serializable]
    public struct SerializedNullable<T>
    {
        public static readonly SerializedNullable<T> Null = default;
        
        public T Value;
        public bool HasValue;

        public SerializedNullable(T? value)
        {
            Value = value!;
            HasValue = value == null;
        }

        public void Deconstruct(out T value, out bool hasValue) => (value, hasValue) = (Value, HasValue);

        public T? AsNullable()
        {
            return (T?)this;
        }
        
        public static implicit operator T?(in SerializedNullable<T> serializedNullable)
        {
            (T value, bool hasValue) = serializedNullable;

            return hasValue ? (T?)value : default;
        }
        
        public static implicit operator SerializedNullable<T>(in T? nullable)
        {
            return new SerializedNullable<T>(nullable);
        }
    }
    
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SerializedNullable<>))]
    public sealed class SerializedNullableDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property.FindPropertyRelative("Value"));
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            SerializedProperty valueProperty = property.FindPropertyRelative("Value");
            SerializedProperty nullProperty = property.FindPropertyRelative("HasValue");

            position = EditorGUI.PrefixLabel(position, label);

            Rect nullPosition = position;
            nullPosition.x += position.width - position.height;
            nullPosition.width = position.height;

            Rect propertyPosition = position;
            propertyPosition.width -= nullPosition.height + EditorGUIUtility.standardVerticalSpacing * 2;

            bool hasValue = EditorGUI.Toggle(nullPosition, nullProperty.boolValue);

            nullProperty.boolValue = hasValue;
            
            if (hasValue)
            {
                EditorGUI.PropertyField(propertyPosition, valueProperty, GUIContent.none, true);
            }
            else
            {
                EditorGUI.LabelField(position, GUIContent.none, new GUIContent("null"));
            }

            EditorGUI.EndProperty();
        }
    }
#endif
}

#endif