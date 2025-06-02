using UnityEditor;
using UnityEngine;

namespace AreYouFruits.Nullability
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

            var valueProperty = property.FindPropertyRelative("value");
            var nullProperty = property.FindPropertyRelative("isInitialized");

            position = EditorGUI.PrefixLabel(position, label);

            var nullPosition = position;
            nullPosition.x += position.width - position.height;
            nullPosition.width = position.height;

            var propertyPosition = position;
            propertyPosition.width -= nullPosition.height + EditorGUIUtility.standardVerticalSpacing * 2;

            var hasValue = EditorGUI.Toggle(nullPosition, nullProperty.boolValue);

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