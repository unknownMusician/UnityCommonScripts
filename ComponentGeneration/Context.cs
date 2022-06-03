using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AreYouFruits.Common.ComponentGeneration
{
    // todo
    public sealed class Context : MonoBehaviour
    {
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Context))]
    public sealed class ContextEditor : Editor
    {
    #nullable disable
        private Type[] _types;
        private string[] _typeNamespaces;
        private string _namespaceFilter = string.Empty;
        private string _typeFilter = string.Empty;

        private string[] _filteredNamespaces;
        private Type[] _filteredByNamespaceTypes;
        private Type[] _filteredTypes;
    #nullable enable
        
        private void OnEnable()
        {
            _types = ReflectionUtils.AllTypes;
            
            _typeNamespaces = ReflectionUtils.AllTypes
                .Select(type => type.Namespace)
                .Select(n => n ?? string.Empty)
                .Distinct()
                .ToArray();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            _filteredNamespaces ??= _typeNamespaces;
            _filteredByNamespaceTypes ??= _types;
            _filteredTypes ??= _types;

            string namespaceFilter = EditorGUILayout.TextField(new GUIContent("Namespace filter"), _namespaceFilter);

            if (namespaceFilter != _namespaceFilter)
            {
                _namespaceFilter = namespaceFilter;
                _filteredNamespaces = _typeNamespaces.Where(n => n.StartsWith(_namespaceFilter)).ToArray();
                _filteredByNamespaceTypes = _types.Where(type => _filteredNamespaces.Contains(type.Namespace)).ToArray();
            }
            
            EditorGUILayout.Popup("Namespace", -1, _filteredNamespaces);

            string typeFilter = EditorGUILayout.TextField(new GUIContent("Type filter"), _typeFilter);

            if (typeFilter != _typeFilter)
            {
                _typeFilter = typeFilter;

                _filteredTypes = _filteredByNamespaceTypes.Where(type => type.Name.StartsWith(_typeFilter))
                    .ToArray();
            }

            EditorGUILayout.Popup("Type", -1, _filteredTypes.Select(type => type.Name).ToArray());
            
            // EditorGUILayout.PropertyField(lookAtPoint);
            
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}
