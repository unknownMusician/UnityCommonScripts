﻿using System.Collections.Generic;
using System.IO;

namespace Exporter;

public static class Properties
{
    public static IReadOnlyList<string> ExportedFileExtensions { get; } = new[]
    {
        "dll",
        "pdb",
        "deps.json",
    };

    public static string ExportDirectoryName { get; } = Path.Combine("Assets", "package", "Compiled");

    public static bool RemoveAreYouFruitsPrefixInExportFolders { get; } = true;

    public static IReadOnlyList<string> SupportedFrameworks { get; } = new[]
    {
        "netstandard2.1",
        "netstandard2.0",
    };
}