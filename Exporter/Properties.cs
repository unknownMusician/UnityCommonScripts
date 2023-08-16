using System.Collections.Generic;

namespace Exporter;

public static class Properties
{
    public static IReadOnlyList<string> ExportedFileExtensions { get; } = new[]
    {
        "dll",
        "pdb",
        "deps.json",
    };

    public static string ExportDirectoryName { get; } = "Export";
    
    public static IReadOnlyList<string> SupportedFrameworks { get; } = new[]
    {
        "netstandard2.1",
        "netstandard2.0",
    };
    
    public static IReadOnlyList<string> AdditionalDirectoryNames { get; } = new[]
    {
        "Shaders",
    };
}