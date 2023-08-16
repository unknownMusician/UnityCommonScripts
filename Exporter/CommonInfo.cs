using System.IO;

namespace Exporter;

public static class CommonInfo
{
    public static string SolutionDirectory { get; } = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
    public static string ExportDirectoryPath { get; } = Path.Combine(SolutionDirectory, Properties.ExportDirectoryName);
}