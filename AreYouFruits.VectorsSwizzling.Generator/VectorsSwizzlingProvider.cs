using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AreYouFruits.VectorsSwizzling.Generator
{
    public static class VectorsSwizzlingProvider
    {
        private static readonly string[] Parameters = { "x", "y", "z", "w" };
        private const string ZeroParameterName = "n";

        public static List<Source> GenerateSwizzlings()
        {
            var results = new List<Source>();

            int[] counts = { 2, 3, 4 };

            foreach (int input in counts)
            {
                foreach (int output in counts)
                {
                    results.Add(new Source(
                        name: $"SwizzlingVector{input}To{output}Extensions.g.cs",
                        content: GenerateVectorSwizzling(input, output)));
                }
            }

            return results;
        }

        private static string GenerateVectorSwizzling(int inputCount, int outputCount)
        {
            var result = new StringBuilder();

            result.AppendLine("using UnityEngine;");
            result.AppendLine("");
            result.AppendLine("namespace AreYouFruits.VectorsSwizzling");
            result.AppendLine("{");
            result.AppendLine($"    public static class SwizzlingVector{inputCount}To{outputCount}Extensions");
            result.AppendLine("    {");
            
            foreach (string s in GenerateVectorSwizzling(outputCount, Parameters.AsSpan().Slice(0, inputCount)))
            {
                result.AppendLine("        " + s);
            }

            result.AppendLine("    }");
            result.AppendLine("}");
            
            return result.ToString();
        }

        private static List<string> GenerateVectorSwizzling(int outputParametersCount, ReadOnlySpan<string> parameters)
        {
            HashSet<int?[]> swizzlingIndices = GenerateSwizzlingsWithZeros(outputParametersCount, parameters.Length);

            string[] lower = parameters.ToArray().Select(p => p.ToLower()).ToArray();
            string[] upper = parameters.ToArray().Select(p => p.ToUpper()).ToArray();

            var results = new List<string>();

            var zeroName = ZeroParameterName.ToUpper();

            foreach (int?[] indices in swizzlingIndices)
            {
                if (indices.All(i => !i.HasValue))
                {
                    continue;
                }
                
                string name = string.Join(string.Empty, indices.Select(i => i is { } j ? upper[j] : zeroName));
            
                string constructorArguments = string.Join(", ", indices.Select((i, position) => i is { } j ? $"v.{lower[j]}" : Parameters[position]));

                string additionalParameters = ToAdditionalParameters(indices);
                
                results.Add($"public static Vector{outputParametersCount} {name}(this Vector{parameters.Length} v{additionalParameters}) => new({constructorArguments});");
            }

            return results;
        }

        private static string ToAdditionalParameters(int?[] indices)
        {
            var result = new StringBuilder();

            for (int position = 0; position < indices.Length; position++)
            {
                if (indices[position] is not { } index)
                {
                    result.Append($", float {Parameters[position]} = 0.0f");
                }
            }
            
            return result.ToString();
        }

        private static HashSet<int[]> GenerateSwizzlingsIndices(int outputParametersCount, int parametersCount)
        {
            var swizzlings = new HashSet<int[]>();

            for (int i = 0; i < parametersCount; i++)
            {
                swizzlings.Add(new[] { i });
            }

            for (int i = 1; i < outputParametersCount; i++)
            {
                foreach (int[] indices in swizzlings.ToArray())
                {
                    swizzlings.Remove(indices);

                    for (int j = 0; j < parametersCount; j++)
                    {
                        swizzlings.Add(indices.Prepend(j).ToArray());
                    }
                }
            }

            return swizzlings;
        }

        private static HashSet<int?[]> GenerateSwizzlingsWithZeros(
            int outputParametersCount,
            int parametersCount
        )
        {
            var result = new HashSet<int?[]>();

            foreach (int[] swizzlingsIndices in GenerateSwizzlingsIndices(outputParametersCount, parametersCount + 1))
            {
                result.Add(swizzlingsIndices.Select(i => i == parametersCount ? (int?)null : i).ToArray());
            }

            return result;
        }
    }
}
