using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using AreYouFruits.EditorGuiUtils.Unity.Editor;
using AreYouFruits.MonoBehaviourUtils.Unity;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AreYouFruits.InterfaceSerialization.Unity.Editor
{
    [CustomPropertyDrawer(typeof(SerializedInterface<>))]
    public class SerializedObjectDrawer : PropertyDrawer
    {
        public enum SerializeType { Interface = 0, Object, Popup }

        public const int PopupWidth = 50;
        public const int GapWidth = 2;

        private SerializeType serializeType = SerializeType.Interface;

        private GameObject choosingGameObject;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var objectProperty = property.FindPropertyRelative("_object");

            var serializedInterface = GetTargetObjectOfProperty(property)!;

            var genericArguments = serializedInterface.GetType().GenericTypeArguments;

            if (genericArguments.Length != 1)
            {
                throw new NotImplementedException();
            }

            var interfaceType = genericArguments.First();

            var popupPosition = new Rect(new Vector2(position.max.x - PopupWidth, position.position.y),
                new Vector2(PopupWidth, position.size.y));

            position = new Rect(position.position, position.size - (PopupWidth + GapWidth) * Vector2.right);

            serializeType = (SerializeType)EditorGUI.EnumPopup(popupPosition, serializeType);

            switch (serializeType)
            {
                case SerializeType.Interface:
                    OnGuiAsInterfaceField(position, objectProperty, label, interfaceType);

                    break;
                case SerializeType.Object:
                    OnGuiAsObjectField(position, objectProperty, label, interfaceType, ref choosingGameObject);

                    break;
                case SerializeType.Popup:
                    OnGuiAsPopupField(position, objectProperty, label, interfaceType);

                    break;
                default: throw new ArgumentOutOfRangeException();
            }

            EditorGUI.EndProperty();
        }

        public static void OnGuiAsInterfaceField(
            Rect position, SerializedProperty objectProperty, GUIContent label, Type interfaceType
        )
        {
            objectProperty.objectReferenceValue = EditorGUI.ObjectField(position, label,
                objectProperty.objectReferenceValue, interfaceType, true);
        }

        public static void OnGuiAsObjectField(
            Rect position, SerializedProperty objectProperty, GUIContent label, Type interfaceType,
            ref GameObject choosingGameObject
        )
        {
            position = EditorGUI.PrefixLabel(position, label);

            Object obj;

            if (choosingGameObject == null)
            {
                obj = EditorGUI.ObjectField(position, objectProperty.objectReferenceValue, typeof(Object), true);

                if (obj == objectProperty.objectReferenceValue)
                {
                    return;
                }
            }
            else
            {
                var objectPosition = new Rect(position.position, new Vector2(position.size.x / 2, position.size.y));

                var componentPosition = new Rect(position.position + (objectPosition.width + GapWidth) * Vector2.right,
                    new Vector2(position.size.x - objectPosition.size.x - GapWidth, position.size.y));

                obj = EditorGUI.ObjectField(objectPosition, choosingGameObject, typeof(Object), true);

                if (obj is GameObject gameObject)
                {
                    var interfaceComponents = gameObject.GetVarianceComponents(interfaceType);

                    if (interfaceComponents.Length == 1)
                    {
                        obj = interfaceComponents[0];
                    }
                    else if (interfaceComponents.Length > 1)
                    {
                        var allComponents = gameObject.GetAllComponents();
                        var count = 0;

                        var index = CustomEditorGUI.Popup(componentPosition, -1,
                            allComponents.Select(c => new GUIContent(count++ + " " + GetName(c))).ToArray(),
                            i => interfaceComponents.Contains(allComponents[i]));

                        if (index >= 0)
                        {
                            obj = allComponents[index];
                        }
                    }
                }
            }

            choosingGameObject = obj as GameObject;

            TrySetObjectReferenceValue(obj, objectProperty, interfaceType);

            static void TrySetObjectReferenceValue(Object value, SerializedProperty objectProperty, Type interfaceType)
            {
                if (value is null || interfaceType.IsInstanceOfType(value))
                {
                    objectProperty.objectReferenceValue = value;
                }
            }
        }

        public static void OnGuiAsPopupField(
            Rect position, SerializedProperty objectProperty, GUIContent label, Type interfaceType
        )
        {
            var gameObjects = Object.FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            var components = gameObjects.SelectMany(g => g.GetVarianceComponents(interfaceType)).ToArray();

            var variants = components.Select(c =>
                {
                    var index =
                        c.gameObject.GetVarianceComponents(interfaceType).Count() <= 1 ?
                            string.Empty :
                            $"[{Array.IndexOf(c.gameObject.GetAllComponents(), c)}] ";

                    return new GUIContent($"{c.gameObject.name}.{index}{GetName(c)}");
                })
                .ToArray();

            var index = Array.IndexOf(components, (Component)objectProperty.objectReferenceValue);

            index = EditorGUI.Popup(position, label, index, variants);

            objectProperty.objectReferenceValue = index == -1 ? null : components[index];
        }

        private static string GetName(Component c)
        {
            return c.GetType().GetMethod("ToString")!.DeclaringType
             == typeof(Object).GetMethod("ToString")!.DeclaringType ?
                    c.GetType().Name :
                    c.ToString();
        }

        public static object GetTargetObjectOfProperty(SerializedProperty prop)
        {
            var path = prop.propertyPath.Replace(".Array.data[", "[");
            object obj = prop.serializedObject.targetObject;

            foreach (var element in path.Split('.'))
            {
                if (element.Contains("["))
                {
                    var elementName = element.Substring(0, element.IndexOf("[", StringComparison.Ordinal));

                    var index = Convert.ToInt32(element.Substring(element.IndexOf("[", StringComparison.Ordinal))
                        .Replace("[", "")
                        .Replace("]", ""));

                    obj = GetValueImp(obj, elementName, index);
                }
                else
                {
                    obj = GetValueImp(obj, element);
                }
            }

            return obj;
        }

        private static object GetValueImp(object source, string name, int index)
        {
            if (!(GetValueImp(source, name) is IEnumerable enumerable))
            {
                return null;
            }

            var enm = enumerable.GetEnumerator();

            for (var i = 0; i <= index; i++)
            {
                if (!enm.MoveNext())
                {
                    return null;
                }
            }

            var result = enm.Current;
            
            if (enm is IDisposable disposableEnm)
            {
                disposableEnm.Dispose();
            }

            return result;
        }

        private static object GetValueImp(object source, string name)
        {
            if (source == null)
            {
                return null;
            }

            var type = source.GetType();

            while (type != null)
            {
                var f = type.GetField(name,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

                if (f != null)
                {
                    return f.GetValue(source);
                }

                var p = type.GetProperty(name,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

                if (p != null)
                {
                    return p.GetValue(source, null);
                }

                type = type.BaseType;
            }

            return null;
        }
    }
}