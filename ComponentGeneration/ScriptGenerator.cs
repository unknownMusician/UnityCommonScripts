#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace AreYouFruits.Common.ComponentGeneration
{
    public static class ScriptGenerator
    {
        private struct FileInfo
        {
            public string FilePath;
            public Type Type;
            public HasComponentAttribute Attribute;
        }

        const string ScriptsPath = @"Assets\Scripts";
        const string LogicRelativePath = "Logic";
        const string ComponentsRelativePath = "Components";
        const string AbstractionsRelativePath = "Abstractions";

        [MenuItem("Are You Fruits?/Script Generation/Generate Components")]
        public static void GenerateComponents()
        {
            // EditorUtility.DisplayDialogComplex(
            //     "Generate Components",
            //     "Do you want to generate both Components and Interfaces?",
            //     "Yes, both of them",
            //     "Cancel",
            //     "No, only Components"
            // );

            string logicPath = Path.Combine(ScriptsPath, LogicRelativePath);

            List<string> filePaths = GetAllFilePaths(logicPath);
            List<FileInfo> filtered = FilterFilesWithAttribute<HasComponentAttribute>(filePaths);
            int createdFilesCount = CreateFiles(filtered);

            Debug.Log($"Created {createdFilesCount} files.");

            if (createdFilesCount > 0)
            {
                AssetDatabase.Refresh();
            }
        }

        private static string GetComponentFileContents(FileInfo fileInfo)
        {
            Type type = fileInfo.Type;

            ConstructorInfo constructor = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public).First();

            ParameterInfo[] parameters = constructor.GetParameters();

            static string GetField(ParameterInfo parameter)
            {
                Type type = parameter.ParameterType;

                string typeAsString = type.GetReadableName();

                if (type.IsInterface)
                {
                    typeAsString = $"SerializedInterface<IComponent<{typeAsString}>>";
                }
                
                return $"[SerializeField] private {typeAsString} _{parameter.Name};";
            }

            static string GetCallParameter(ParameterInfo parameter)
            {
                string callParameter = $"_{parameter.Name}";

                if (parameter.ParameterType.IsInterface)
                {
                    callParameter += ".GetHeldItem()";
                }
                
                return callParameter;
            }

            string fields = parameters.Select(GetField)
                .Aggregate(
                    (a, b) => a
                      + @"
        "
                      + b
                );

            string callParameters = parameters.Select(GetCallParameter)
                .Aggregate(
                    (a, b) => a
                      + @",
                "
                      + b
                );
            
            return $@"using {nameof(ComponentGeneration)};

namespace {type.Namespace}
{{
    todo: check
    public sealed class {type.Name}Component : AbstractComponent<{type.Name}>
    {{
    #nullable disable
        {fields}
    #nullable enable

        protected override {type.Name} Create()
        {{
            return new {type.Name}
            (
                {callParameters}
            )
        }}
    }}
}}";
        }

        private static string GetInterfaceFileContents(string typeName, string typeNamespace)
        {
            return $@"namespace {typeNamespace}
{{
    todo: check
    public interface I{typeName} {{ }}
}}";
        }

        private static bool TryCreateComponentFile(FileInfo fileInfo)
        {
            string logicPath = Path.Combine(ScriptsPath, LogicRelativePath);
            string componentsPath = Path.Combine(ScriptsPath, ComponentsRelativePath);

            string componentPath =
                fileInfo.FilePath.Replace(logicPath, componentsPath).Replace(".cs", "Component.cs");

            string componentFolderPath = componentPath[..componentPath.LastIndexOf('\\')];

            if (!Directory.Exists(componentFolderPath))
            {
                Directory.CreateDirectory(componentFolderPath);
            }

            if (!File.Exists(componentPath))
            {
                using FileStream file = File.Create(componentPath);
                using var writer = new StreamWriter(file);
                writer.Write(GetComponentFileContents(fileInfo));

                return true;
            }

            return false;
        }

        private static bool TryCreateInterfaceFile(FileInfo fileInfo)
        {
            if (!fileInfo.Attribute.HasInterfaceAlso)
            {
                return false;
            }
            
            string logicPath = Path.Combine(ScriptsPath, LogicRelativePath);
            string abstractionsPath = Path.Combine(ScriptsPath, AbstractionsRelativePath);

            if (!Directory.Exists(abstractionsPath))
            {
                Directory.CreateDirectory(abstractionsPath);
            }

            string abstractionPath = fileInfo.FilePath.Replace(logicPath, abstractionsPath);
            int lastAbstractionSlashIndex = abstractionPath.LastIndexOf('\\');

            string abstractionFolderPath = abstractionPath[..abstractionPath.LastIndexOf('\\')];

            if (!Directory.Exists(abstractionFolderPath))
            {
                Directory.CreateDirectory(abstractionFolderPath);
            }

            abstractionPath = abstractionPath[..lastAbstractionSlashIndex]
              + "\\I"
              + abstractionPath[(lastAbstractionSlashIndex + 1)..];

            if (!File.Exists(abstractionPath))
            {
                using FileStream file = File.Create(abstractionPath);
                using var writer = new StreamWriter(file);
                writer.Write(GetInterfaceFileContents(fileInfo.Type.Name, fileInfo.Type.Namespace));

                return true;
            }

            return false;
        }

        private static int CreateFiles(List<FileInfo> fileInfos)
        {
            int createdFilesCount = 0;

            foreach (FileInfo fileInfo in fileInfos)
            {
                if (TryCreateComponentFile(fileInfo))
                {
                    createdFilesCount++;
                }

                if (TryCreateInterfaceFile(fileInfo))
                {
                    createdFilesCount++;
                }
            }

            return createdFilesCount;
        }

        private static List<FileInfo> FilterFilesWithAttribute<TAttribute>(List<string> filePaths)
            where TAttribute : Attribute
        {
            string attributeName = typeof(TAttribute).Name;

            if (attributeName.EndsWith("Attribute", StringComparison.Ordinal))
            {
                attributeName = attributeName.Substring(0, attributeName.Length - "Attribute".Length);
            }

            return FilterFilesWithAttribute(filePaths, attributeName);
        }

        private static List<FileInfo> FilterFilesWithAttribute(List<string> filePaths, string attributeName)
        {
            var filtered = new List<FileInfo>();

            foreach (string filePath in filePaths)
            {
                if (!File.Exists(filePath))
                {
                    throw new Exception($"File \"{filePath}\" does not exist.");
                }

                string fileText = File.ReadAllText(filePath);

                int classTextIndex = fileText.IndexOf("class", StringComparison.Ordinal);
                int namespaceTextIndex = fileText.IndexOf("namespace", StringComparison.Ordinal);

                if (classTextIndex == -1)
                {
                    continue;
                }

                int classTextEndIndex = fileText.IndexOf('{', classTextIndex);
                int inheritCharacterIndex = fileText.IndexOf(':', classTextIndex);

                if ((inheritCharacterIndex != -1) && (classTextEndIndex == -1 || classTextEndIndex > inheritCharacterIndex))
                {
                    classTextEndIndex = inheritCharacterIndex;
                }

                string typeName = fileText.Substring(
                        classTextIndex + "class ".Length,
                        classTextEndIndex - classTextIndex - "class ".Length
                    )
                    .Replace(" ", string.Empty)
                    .Replace("\r", string.Empty)
                    .Replace("\n", string.Empty)
                    .Replace("@", string.Empty);

                string typeNamespace = fileText.Substring(
                        namespaceTextIndex + "namespace ".Length,
                        fileText.IndexOf('{', namespaceTextIndex) - namespaceTextIndex - "namespace ".Length
                    )
                    .Replace(" ", string.Empty)
                    .Replace("\r", string.Empty)
                    .Replace("\n", string.Empty)
                    .Replace("@", string.Empty);

                Type type = ReflectionUtils.AllTypes.First(
                    type => type.Name == typeName && type.Namespace == typeNamespace
                );

                HasComponentAttribute attribute = type.GetCustomAttribute<HasComponentAttribute>();

                if (attribute is not null)
                {
                    filtered.Add(new FileInfo { FilePath = filePath, Type = type, Attribute = attribute, });
                }
            }

            return filtered;
        }

        public static List<string> GetAllFilePaths(string directoryPath)
        {
            return GetAllFilePaths(directoryPath, new List<string>());
        }

        public static List<string> GetAllFilePaths(string directoryPath, List<string> filePaths)
        {
            if (!Directory.Exists(directoryPath))
            {
                Debug.LogWarning($"Directory \"{directoryPath}\" does not exist.");

                return filePaths;
            }

            filePaths.AddRange(
                Directory.GetFiles(directoryPath).Where(file => file.EndsWith(".cs", StringComparison.Ordinal))
            );

            foreach (string directory in Directory.GetDirectories(directoryPath))
            {
                GetAllFilePaths(directory, filePaths);
            }

            return filePaths;
        }
    }
}

#endif
