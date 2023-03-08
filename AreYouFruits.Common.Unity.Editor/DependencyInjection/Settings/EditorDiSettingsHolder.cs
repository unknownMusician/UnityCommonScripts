using System;
using System.IO;
using AreYouFruits.DependencyInjection;
using AreYouFruits.DependencyInjection.ContextInitialization;
using Starfish.Utils;
using UnityEngine;

namespace Starfish.TempDi.Settings
{
    public static class EditorDiSettingsHolder
        // todo: repeating class
    {
        private const string SettingsLocalPath = "Assets/Resources/DiSettings.asset";
        private static readonly string SettingsPath = Application.dataPath + "/Resources/DiSettings.asset";

        private static DiSettings? settings;

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
            DiSettings settings = ScriptableObject.CreateInstance<DiSettings>();

            string directory = Path.GetDirectoryName(SettingsPath) + '\\';
                
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
            if (!Settings.TryGet(out DiSettings settings))
            {
                return;
            }

            foreach (Binding binding in settings.Bindings)
            {
                var type = Type.GetType(binding.TypeName);

                if (type is null)
                {
                    throw new InvalidProgramException();
                }

                container.Bind(type).To(binding.Object);
            }
        }
    }
}