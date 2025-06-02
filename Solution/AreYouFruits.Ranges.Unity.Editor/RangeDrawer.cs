using AreYouFruits.EditorGuiUtils.Unity.Editor;
using UnityEditor;
using UnityEngine;

namespace AreYouFruits.Ranges.Unity.Editor
{
    [CustomPropertyDrawer(typeof(Range<>))]
    public sealed class RangeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (IsSingleLine(property))
            {
                return base.GetPropertyHeight(property, label);
            }

            var minProperty = property.FindPropertyRelative("Min");
            var maxProperty = property.FindPropertyRelative("Max");

            if ((minProperty == null) || (maxProperty == null))
            {
                return EditorGUIUtility.singleLineHeight;
            }
            
            return EditorGUI.GetPropertyHeight(minProperty) + EditorGUI.GetPropertyHeight(maxProperty);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, label);

            var minProperty = property.FindPropertyRelative("Min");
            var maxProperty = property.FindPropertyRelative("Max");

            Rect minPosition;
            Rect maxPosition;

            var minLabel = new GUIContent(minProperty.name);
            var maxLabel = new GUIContent(maxProperty.name);

            var minMaxLabelWidth = 26.0f;
            const float isBoundLabelWidth = 40.0f;

            if (IsSingleLine(property))
            {
                minPosition = position;
                minPosition.width = (int)(position.width - 2.0f) / 2;

                maxPosition = position;
                maxPosition.x += minPosition.width + 2.0f;
                maxPosition.width = (int)(position.width - 2.0f - minPosition.width);
            }
            else
            {
                minPosition = position;
                minPosition.height = (int)(position.height - 2.0f) / 2;

                maxPosition = position;
                maxPosition.y += minPosition.height + 2.0f;
                maxPosition.height = (int)(position.height - 2.0f - minPosition.height);

                minMaxLabelWidth = isBoundLabelWidth;
            }

            CustomEditorGUI.PrefixLabel(minPosition, 0.0f, new GUIContent(""));

            minPosition = CustomEditorGUI.PrefixLabel(minPosition, minMaxLabelWidth, minLabel);
            maxPosition = CustomEditorGUI.PrefixLabel(maxPosition, minMaxLabelWidth, maxLabel);

            minLabel = new GUIContent("");
            maxLabel = new GUIContent("");

            EditorGUI.PropertyField(minPosition, minProperty, minLabel);
            EditorGUI.PropertyField(maxPosition, maxProperty, maxLabel);

            EditorGUI.EndProperty();
        }

        private static bool IsSingleLine(SerializedProperty property)
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
