#if UNITY_EDITOR

using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AreYouFruits.Common.VoxelImport
{
    public class VoxelObjImporterWindow : EditorWindow
    {
        protected const string DefaultModelsPath = "Assets/Models/Voxel/";
        protected readonly VoxelObjImporter ImportHelper = new VoxelObjImporter();

        protected string SourceDirectory = string.Empty;
        protected string DestinationDirectory = string.Empty;

        [MenuItem("Are You Fruits?/VoxelImport/.obj Import Helper")]
        public static void ShowWindow()
        {
            GetWindow<VoxelObjImporterWindow>();
        }

        protected virtual void OnGUI()
        {
            //GUILayout.Label("Base Settings", EditorStyles.boldLabel);
            SourceDirectory = EditorGUILayout.TextField("Source Directory", SourceDirectory);
            DestinationDirectory = EditorGUILayout.TextField("Destination Directory", DestinationDirectory);

            if (!SourceDirectory.StartsWith("Assets/") || !DestinationDirectory.StartsWith("Assets/"))
            {
                EditorGUILayout.HelpBox("Directories should start with 'Assets/'", MessageType.Error);
            }
            else if (GUILayout.Button("Palette to Materials"))
            {
                ChangePaletteToMaterialsInDirectoryAndSubdirectories(SourceDirectory, DestinationDirectory);
                AssetDatabase.Refresh();
            }
        }

        private void ChangePaletteToMaterialsInDirectoryAndSubdirectories(
            string sourceDirectory, string destinationDirectory
        )
        {
            foreach (string sourceFile in Directory.GetFiles(sourceDirectory))
            {
                if (Path.GetExtension(sourceFile) != ".obj")
                {
                    continue;
                }
                
                ImportHelper.ChangePaletteToMaterials(sourceFile, destinationDirectory);
                Debug.Log($"Updated {sourceFile}");
            }

            foreach (string newSourceDirectory in Directory.GetDirectories(sourceDirectory))
            {
                string newDestinationDirectory = Path.Combine(
                    destinationDirectory,
                    Path.GetFileName(newSourceDirectory)
                );

                ChangePaletteToMaterialsInDirectoryAndSubdirectories(newSourceDirectory, newDestinationDirectory);
            }
        }
    }

    // todo
}

#endif
