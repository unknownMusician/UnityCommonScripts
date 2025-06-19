using UnityEditor;
using UnityEngine;

namespace AreYouFruits.Nullability
{
    [CustomPropertyDrawer(typeof(Optional<>))]
    public sealed class OptionalDrawer : PropertyDrawer
    {
        private GUIContent nullGuiContent;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var valueProperty = property.FindPropertyRelative("value");

            if (valueProperty == null)
            {
                return 0;
            }
            
            return EditorGUI.GetPropertyHeight(valueProperty, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            nullGuiContent ??= new GUIContent("null");
            
            EditorGUI.BeginProperty(position, label, property);

            var valueProperty = property.FindPropertyRelative("value");
            var nullProperty = property.FindPropertyRelative("isInitialized");

            if (valueProperty == null || nullProperty == null)
            {
                EditorGUI.EndProperty();
                return;
            }

            position = EditorGUI.PrefixLabel(position, label);

            var nullPosition = position;
            nullPosition.x += position.width - position.height;
            nullPosition.width = position.height;

            var propertyPosition = position;
            propertyPosition.width -= nullPosition.height + EditorGUIUtility.standardVerticalSpacing * 2;

            EditorGUI.PropertyField(nullPosition, nullProperty, GUIContent.none, true);

            if (nullProperty.boolValue)
            {
                EditorGUI.PropertyField(propertyPosition, valueProperty, GUIContent.none, true);
            }
            else
            {
                EditorGUI.LabelField(position, GUIContent.none, nullGuiContent);
            }

            EditorGUI.EndProperty();
        }
    }
}