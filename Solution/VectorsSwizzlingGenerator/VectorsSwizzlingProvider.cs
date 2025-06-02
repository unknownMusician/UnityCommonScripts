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

            foreach (var input in counts)
            {
                foreach (var output in counts)
                {
                    results.Add(new Source(
                        name: $"SwizzlingVector{input}To{output}Extensions.cs",
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
            
            foreach (var s in GenerateVectorSwizzling(outputCount, Parameters.AsSpan().Slice(0, inputCount)))
            {
                result.AppendLine("        // ReSharper disable once InconsistentNaming");
                result.AppendLine("        " + s);
            }

            result.AppendLine("    }");
            result.AppendLine("}");
            
            return result.ToString();
        }

        private static List<string> GenerateVectorSwizzling(int outputParametersCount, ReadOnlySpan<string> parameters)
        {
            var swizzlingIndices = GenerateSwizzlingsWithZeros(outputParametersCount, parameters.Length);

            var lower = parameters.ToArray().Select(p => p.ToLower()).ToArray();
            var upper = parameters.ToArray().Select(p => p.ToUpper()).ToArray();

            var results = new List<string>();

            var zeroName = ZeroParameterName.ToUpper();

            foreach (var indices in swizzlingIndices)
            {
                if (indices.All(i => !i.HasValue))
                {
                    continue;
                }
                
                var name = string.Join(string.Empty, indices.Select(i => i is { } j ? upper[j] : zeroName));
            
                var constructorArguments = string.Join(", ", indices.Select((i, position) => i is { } j ? $"v.{lower[j]}" : Parameters[position]));

                var additionalParameters = ToAdditionalParameters(indices);
                
                results.Add($"public static Vector{outputParametersCount} {name}(this Vector{parameters.Length} v{additionalParameters}) => new({constructorArguments});");
            }

            return results;
        }

        private static string ToAdditionalParameters(int?[] indices)
        {
            var result = new StringBuilder();

            for (var position = 0; position < indices.Length; position++)
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

            for (var i = 0; i < parametersCount; i++)
            {
                swizzlings.Add(new[] { i });
            }

            for (var i = 1; i < outputParametersCount; i++)
            {
                foreach (var indices in swizzlings.ToArray())
                {
                    swizzlings.Remove(indices);

                    for (var j = 0; j < parametersCount; j++)
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

            foreach (var swizzlingsIndices in GenerateSwizzlingsIndices(outputParametersCount, parametersCount + 1))
            {
                result.Add(swizzlingsIndices.Select(i => i == parametersCount ? (int?)null : i).ToArray());
            }

            return result;
        }
    }
}
