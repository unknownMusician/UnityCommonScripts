using UnityEditor;
using UnityEngine;

namespace AreYouFruits.Common
{
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
}