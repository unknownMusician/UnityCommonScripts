using System;
using System.IO;
using AreYouFruits.DependencyInjection.ContextInitialization;
using AreYouFruits.DependencyInjection.TypeResolvers;
using AreYouFruits.DependencyInjection.Unity.Settings;
using AreYouFruits.Nullability;
using UnityEngine;

namespace AreYouFruits.DependencyInjection.Unity.Editor.Settings
{
    public static class EditorDiSettingsHolder
        // todo: repeating class
    {
        private const string SettingsLocalPath = "Assets/Resources/DiSettings.asset";
        private static readonly string SettingsPath = Application.dataPath + "/Resources/DiSettings.asset";

        private static DiSettings settings;

        public static Optional<DiSettings> Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = Load();
                }

                return settings;
            }
        }

        private static DiSettings Load()
        {
            var settings = UnityEditor.AssetDatabase.LoadAssetAtPath<DiSettings>(SettingsLocalPath);

            if (settings != null)
            {
                return settings;
            }

            settings = ScriptableObject.CreateInstance<DiSettings>();
            settings.Bindings = Array.Empty<Binding>();
            
            var directory = Path.GetDirectoryName(SettingsPath) + '\\';
                
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            UnityEditor.AssetDatabase.CreateAsset(settings, SettingsLocalPath);

            return settings;
        }

        [ContextInitializer]
        private static void TryBind(IDiContainer container)
        {
            if (!Settings.TryGet(out var settings))
            {
                return;
            }

            var containsUnassigned = false;
            
            foreach (var binding in settings.Bindings)
            {
                if (binding.Object is null)
                {
                    containsUnassigned = true;
                    continue;
                }
                
                var type = Type.GetType(binding.TypeName);

                if (type is null)
                {
                    Debug.LogWarning($"Type {binding.TypeName} from DiSettings cannot be deserialized.", settings);
                    continue;
                }

                container.Bind(type).ToSingleton(binding.Object);
            }

            if (containsUnassigned)
            {
                Debug.LogWarning("There are unassigned fields in DiSettings.", settings);
            }
        }
    }
}