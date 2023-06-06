using AreYouFruits.Common.Unity.DependencyInjection.Settings;
using UnityEditor;

namespace AreYouFruits.TempDi.Settings
{
    public sealed class DiSettingsProvider : SettingsProvider
    {
        private const string SettingsPath = "Project/Dependency Injection";
        private const SettingsScope Scope = SettingsScope.Project;

        private DiSettings lastSettings;
        private SerializedObject lastSerialized;

        private DiSettingsProvider() : base(SettingsPath, Scope) { }

        [SettingsProvider]
        private static SettingsProvider Get()
        {
            return new DiSettingsProvider();
        }

        public override void OnGUI(string searchContext)
        {
            if (EditorDiSettingsHolder.Settings.TryGet(out DiSettings settings))
            {
                if (settings != lastSettings)
                {
                    lastSettings = settings;
                    lastSerialized = new SerializedObject(settings);
                }
                
                EditorGUILayout.PropertyField(lastSerialized.FindProperty("bindings"));
                lastSerialized.ApplyModifiedProperties();
            }
        }
    }
}