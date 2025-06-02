using System.IO;

namespace Exporter;

public static class CommonInfo
{
    public static string SolutionDirectory { get; } = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
    public static string ProjectDirectory { get; } = Directory.GetParent(SolutionDirectory).FullName;
    public static string ExportDirectoryPath { get; } = Path.Combine(ProjectDirectory, Properties.ExportDirectoryName);
}