using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace AreYouFruits.Common.VoxelImport
{
    public class VoxelObjImporter
    {
        protected StringBuilder Builder = new StringBuilder();
        protected Dictionary<int, StringBuilder> MaterialFaces = new Dictionary<int, StringBuilder>();

        public virtual void ChangePaletteToMaterials(string sourceFile, string destinationDirectory)
        {
            if (!File.Exists(sourceFile))
            {
                throw new FileNotFoundException();
            }

            string objBody = File.ReadAllText(sourceFile);
            
            string sourceFileName = Path.GetFileName(sourceFile);
            string sourceFileNameWithoutExtension = Path.GetFileNameWithoutExtension(sourceFile);

            string destinationFile = Path.Combine(destinationDirectory, sourceFileName);

            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            File.WriteAllText(
                destinationFile,
                UpdateFileBody(objBody, sourceFileNameWithoutExtension, out string mtlBody)
            );

            File.WriteAllText(Path.ChangeExtension(destinationFile, ".mtl"), mtlBody);
        }

        protected virtual string UpdateFileBody(string objBody, string fileName, out string mtlBody)
        {
            Builder = new StringBuilder();
            MaterialFaces = new Dictionary<int, StringBuilder>();

            string[] lines = objBody.Split('\n');

            Builder.Append($"mtllib {fileName}.mtl\n");

            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    ProcessLine(lines[i], i, fileName);
                }
                catch (Exception ex)
                {
                    throw new SyntaxErrorException($"File: {fileName}, line: {i}", ex);
                }
            }

            mtlBody = ToMtlBody(MaterialFaces);

            return Builder.ToString();
        }

        protected virtual string ToMtlBody(Dictionary<int, StringBuilder> materialFaces)
        {
            var mtlBuilder = new StringBuilder();

            foreach (KeyValuePair<int, StringBuilder> face in materialFaces)
            {
                Builder.Append($"usemtl M{face.Key}\n");
                Builder.Append(face.Value);

                mtlBuilder.Append($"newmtl M{face.Key}\n");
            }

            return mtlBuilder.ToString();
        }

        protected virtual void ProcessLine(string line, int lineIndex, string fileName)
        {
            if (line.StartsWith("#", StringComparison.Ordinal)) { }

            if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
            {
                return;
            }

            if (line.StartsWith("mtllib", StringComparison.Ordinal)
             || line.StartsWith("usemtl", StringComparison.Ordinal))
            {
                return;
            }

            if (line.StartsWith("o", StringComparison.Ordinal))
            {
                Builder.Append($"g {fileName}\n");

                return;
            }

            if (line.StartsWith("f", StringComparison.Ordinal))
            {
                int startIndex = line.IndexOf('/') + 1;
                int endIndex = line.IndexOf('/', startIndex);
                string textureIndexAsString = line.Substring(startIndex, endIndex - startIndex);

                if (string.IsNullOrEmpty(textureIndexAsString))
                {
                    return;
                }

                int textureIndex = int.Parse(textureIndexAsString);
                Append(MaterialFaces, textureIndex, line + '\n');

                return;
            }

            Builder.Append(line + '\n');
        }

        protected virtual void Append(Dictionary<int, StringBuilder> builders, int key, string value)
        {
            if (!builders.TryGetValue(key, out StringBuilder builder))
            {
                builder = new StringBuilder();
                builders[key] = builder;
            }

            builder.Append(value);
        }
    }
}
