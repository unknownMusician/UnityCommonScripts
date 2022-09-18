#if UNITY_2021_3

using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AreYouFruits.Common
{
    public static class SerializedNullableExtensions
    {
        public static T? AsNullable<T>(SerializedNullable<T> serializedNullable)
            where T : struct
        {
            return serializedNullable.HasValue ? serializedNullable.Value : null;
        }
    }

    [Serializable]
    public struct SerializedNullable<T> : IEquatable<SerializedNullable<T>>, IEquatable<T>
    {
        public static readonly SerializedNullable<T> Null = default;

        public T Value;
        public bool HasValue;

        public SerializedNullable(T value, bool hasValue)
        {
            Value = value;
            HasValue = hasValue;
        }

        public void Deconstruct(out T value, out bool hasValue) => (value, hasValue) = (Value, HasValue);

        public bool IsNull(out T value)
        {
            if (HasValue)
            {
                value = Value;
                return false;
            }

            value = default;
            return true;
        }

        public bool Equals(T other)
        {
            return !IsNull(out T value) && EqualityComparer<T>.Default.Equals(value, other);
        }
        public bool Equals(SerializedNullable<T> other)
        {
            if (HasValue != other.HasValue)
            {
                return false;
            }

            if (!HasValue)
            {
                return true;
            }
            
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            return obj is SerializedNullable<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, HasValue);
        }

        public static bool operator ==(
            SerializedNullable<T> serializedNullable1, SerializedNullable<T> serializedNullable2
        )
        {
            return serializedNullable1.Equals(serializedNullable2);
        }

        public static bool operator !=(
            SerializedNullable<T> serializedNullable1, SerializedNullable<T> serializedNullable2
        )
        {
            return !serializedNullable1.Equals(serializedNullable2);
        }

        public static bool operator ==(
            SerializedNullable<T> serializedNullable, T nullable
        )
        {
            return serializedNullable.Equals(nullable);
        }

        public static bool operator !=(
            SerializedNullable<T> serializedNullable, T nullable
        )
        {
            return !serializedNullable.Equals(nullable);
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