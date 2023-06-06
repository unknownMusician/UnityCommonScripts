using System;
using AreYouFruits.Common.DependencyInjection.ContextInitialization;
using AreYouFruits.Common.DependencyInjection.Extensions.Binding.Singleton;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;
using AreYouFruits.Utils;
using UnityEngine;

namespace AreYouFruits.Common.Unity.DependencyInjection.Settings
{
    public static class DiSettingsHolder
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
            return Resources.Load<DiSettings>(SettingsPath);
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

                container.Bind(type).ToSingleton(binding.Object);
            }
        }
    }
}