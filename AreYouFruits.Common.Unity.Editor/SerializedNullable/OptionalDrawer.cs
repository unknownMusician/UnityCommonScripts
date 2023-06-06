using AreYouFruits.Utils;
using UnityEditor;
using UnityEngine;

namespace AreYouFruits.Common
{
    [CustomPropertyDrawer(typeof(Optional<>))]
    public sealed class OptionalDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property.FindPropertyRelative("value"), label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty valueProperty = property.FindPropertyRelative("value");
            SerializedProperty nullProperty = property.FindPropertyRelative("isInitialized");

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
}