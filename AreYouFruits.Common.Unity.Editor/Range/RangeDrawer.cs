using UnityEditor;
using UnityEngine;

namespace AreYouFruits.Common
{
    [CustomPropertyDrawer(typeof(Range<>))]
    [CustomPropertyDrawer(typeof(UnmanagedRange<>))]
    public sealed class RangeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (IsSingleLine(property, label))
            {
                return base.GetPropertyHeight(property, label);
            }
            
            SerializedProperty minProperty = property.FindPropertyRelative("Min");
            SerializedProperty maxProperty = property.FindPropertyRelative("Max");
            SerializedProperty isBoundedProperty = property.FindPropertyRelative("IsBounded");

            return EditorGUI.GetPropertyHeight(minProperty)
              + EditorGUI.GetPropertyHeight(maxProperty)
              + EditorGUI.GetPropertyHeight(isBoundedProperty);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            position = EditorGUI.PrefixLabel(position, label);

            bool guiEnabled = GUI.enabled;
            
            SerializedProperty minProperty = property.FindPropertyRelative("Min");
            SerializedProperty maxProperty = property.FindPropertyRelative("Max");
            SerializedProperty isBoundedProperty = property.FindPropertyRelative("IsBounded");

            Rect minPosition;
            Rect maxPosition;
            Rect isBoundedPosition;

            GUIContent minLabel = new GUIContent(minProperty.name);
            GUIContent maxLabel = new GUIContent(maxProperty.name);
            GUIContent isBoundedLabel = new GUIContent("Bound");
            
            float minMaxLabelWidth = 26.0f;
            const float isBoundLabelWidth = 40.0f;

            if (IsSingleLine(property, label))
            {
                minPosition = position; 
                minPosition.width = (int)(position.width - 4.0f) / 3;

                maxPosition = position;
                maxPosition.x += minPosition.width + 2.0f;
                maxPosition.width = (int)(position.width - 4.0f - minPosition.width) / 2;

                isBoundedPosition = position;
                isBoundedPosition.x += minPosition.width + maxPosition.width + 4.0f;
                isBoundedPosition.width = position.width - 4.0f - minPosition.width - minPosition.width;
            }
            else
            {
                minPosition = position; 
                minPosition.height = (int)(position.height - 4.0f) / 3;

                maxPosition = position;
                maxPosition.y += minPosition.height + 2.0f;
                maxPosition.height = (int)(position.height - 4.0f - minPosition.height) / 2;

                isBoundedPosition = position;
                isBoundedPosition.y += minPosition.height + maxPosition.height + 4.0f;
                isBoundedPosition.height = position.height - 4.0f - minPosition.height - minPosition.height;

                minMaxLabelWidth = isBoundLabelWidth;
            }
            
            CustomEditorGUI.PrefixLabel(minPosition, 0.0f, new GUIContent(""));
                
            GUI.enabled &= isBoundedProperty.boolValue;

            minPosition = CustomEditorGUI.PrefixLabel(minPosition, minMaxLabelWidth, minLabel);
            maxPosition = CustomEditorGUI.PrefixLabel(maxPosition, minMaxLabelWidth, maxLabel);
                
            GUI.enabled = guiEnabled;
                
            isBoundedPosition = CustomEditorGUI.PrefixLabel(isBoundedPosition, isBoundLabelWidth, isBoundedLabel);

            minLabel = new GUIContent("");
            maxLabel = new GUIContent("");
            isBoundedLabel = new GUIContent("");
            
            EditorGUI.PropertyField(isBoundedPosition, isBoundedProperty, isBoundedLabel);

            GUI.enabled &= isBoundedProperty.boolValue;
            
            EditorGUI.PropertyField(minPosition, minProperty, minLabel);
            EditorGUI.PropertyField(maxPosition, maxProperty, maxLabel);
            
            GUI.enabled = guiEnabled;
            
            EditorGUI.EndProperty();
        }

        private bool IsSingleLine(SerializedProperty property, GUIContent label)
        {
            switch (property.FindPropertyRelative("Min").propertyType)
            {
                case SerializedPropertyType.Integer:
                case SerializedPropertyType.Boolean:
                case SerializedPropertyType.Float:
                case SerializedPropertyType.String:
                case SerializedPropertyType.ObjectReference:
                case SerializedPropertyType.LayerMask:
                case SerializedPropertyType.Enum:
                case SerializedPropertyType.Character:
                case SerializedPropertyType.AnimationCurve:
                case SerializedPropertyType.Gradient:
                case SerializedPropertyType.Color:
                    return true;
                case SerializedPropertyType.ExposedReference:
                case SerializedPropertyType.ManagedReference:
                case SerializedPropertyType.Generic:
                case SerializedPropertyType.Vector2:
                case SerializedPropertyType.Vector3:
                case SerializedPropertyType.Vector4:
                case SerializedPropertyType.Rect:
                case SerializedPropertyType.ArraySize:
                case SerializedPropertyType.Bounds:
                case SerializedPropertyType.Quaternion:
                case SerializedPropertyType.FixedBufferSize:
                case SerializedPropertyType.Vector2Int:
                case SerializedPropertyType.Vector3Int:
                case SerializedPropertyType.RectInt:
                case SerializedPropertyType.BoundsInt:
                default: 
                    return false;
            }
        }
    }
}
