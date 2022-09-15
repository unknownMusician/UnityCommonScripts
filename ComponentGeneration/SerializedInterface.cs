#if UNITY_2021_3_8

using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using AreYouFruits.Common.InspectorValidation;
using UnityEngine;
using Object = UnityEngine.Object;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AreYouFruits.Common.ComponentGeneration
{
    [Serializable]
    public struct SerializedInterface<TInterface>
        where TInterface : class
    {
    #nullable disable
        [SerializeField] private Object _object;
    #nullable enable

        public SerializedInterface(TInterface value)
        {
            _object = value as Object;
        }

        public TInterface Interface => _object as TInterface ?? throw new BehaviourNotInitializedException();
        public Object AsObject => _object;

        public static implicit operator TInterface(SerializedInterface<TInterface> serializedInterface)
        {
            return serializedInterface.Interface;
        }

        public static implicit operator SerializedInterface<TInterface>(TInterface @interface)
        {
            return new SerializedInterface<TInterface>(@interface);
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SerializedInterface<>))]
    public class SerializedObjectDrawer : PropertyDrawer
    {
        public enum SerializeType { Interface = 0, Object, Popup }

        public const int PopupWidth = 50;
        public const int GapWidth = 2;

        private SerializeType _serializeType = SerializeType.Interface;

        private GameObject? _choosingGameObject;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty objectProperty = property.FindPropertyRelative("_object");

            object serializedInterface = GetTargetObjectOfProperty(property)!;

            Type[] genericArguments = serializedInterface.GetType().GenericTypeArguments;

            if (genericArguments.Length != 1)
            {
                throw new NotImplementedException();
            }

            Type interfaceType = genericArguments.First();

            Rect popupPosition = new Rect(new Vector2(position.max.x - PopupWidth, position.position.y),
                new Vector2(PopupWidth, position.size.y));

            position = new Rect(position.position, position.size - (PopupWidth + GapWidth) * Vector2.right);

            _serializeType = (SerializeType)EditorGUI.EnumPopup(popupPosition, _serializeType);

            switch (_serializeType)
            {
                case SerializeType.Interface:
                    OnGuiAsInterfaceField(position, objectProperty, label, interfaceType);

                    break;
                case SerializeType.Object:
                    OnGuiAsObjectField(position, objectProperty, label, interfaceType, ref _choosingGameObject);

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
            ref GameObject? choosingGameObject
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
                    Component[] interfaceComponents = gameObject.GetVarianceComponents(interfaceType);

                    if (interfaceComponents.Length == 1)
                    {
                        obj = interfaceComponents[0];
                    }
                    else if (interfaceComponents.Length > 1)
                    {
                        Component[] allComponents = gameObject.GetAllComponents();
                        int count = 0;

                        int index = CustomEditorGUI.Popup(componentPosition, -1,
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

            static void TrySetObjectReferenceValue(Object? value, SerializedProperty objectProperty, Type interfaceType)
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
            GameObject[] gameObjects = Object.FindObjectsOfType<GameObject>();

            Component[] components = gameObjects.SelectMany(g => g.GetVarianceComponents(interfaceType)).ToArray();

            GUIContent[] variants = components.Select(c =>
                                              {
                                                  string index =
                                                      c.gameObject.GetVarianceComponents(interfaceType).Count() <= 1 ?
                                                          string.Empty :
                                                          $"[{Array.IndexOf(c.gameObject.GetAllComponents(), c)}] ";

                                                  return new GUIContent($"{c.gameObject.name}.{index}{GetName(c)}");
                                              })
                                              .ToArray();

            int index = Array.IndexOf(components, (Component)objectProperty.objectReferenceValue);

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

        public static object? GetTargetObjectOfProperty(SerializedProperty prop)
        {
            string path = prop.propertyPath.Replace(".Array.data[", "[");
            object? obj = prop.serializedObject.targetObject;

            foreach (string element in path.Split('.'))
            {
                if (element.Contains("["))
                {
                    string elementName = element.Substring(0, element.IndexOf("[", StringComparison.Ordinal));

                    int index = Convert.ToInt32(element.Substring(element.IndexOf("[", StringComparison.Ordinal))
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

        private static object? GetValueImp(object? source, string name, int index)
        {
            if (!(GetValueImp(source, name) is IEnumerable enumerable))
            {
                return null;
            }

            IEnumerator enm = enumerable.GetEnumerator();

            for (int i = 0; i <= index; i++)
            {
                if (!enm.MoveNext())
                {
                    return null;
                }
            }

            return enm.Current;
        }

        private static object? GetValueImp(object? source, string name)
        {
            if (source == null)
            {
                return null;
            }

            Type? type = source.GetType();

            while (type != null)
            {
                FieldInfo? f = type.GetField(name,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

                if (f != null)
                {
                    return f.GetValue(source);
                }

                PropertyInfo? p = type.GetProperty(name,
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
#endif
}

#endif