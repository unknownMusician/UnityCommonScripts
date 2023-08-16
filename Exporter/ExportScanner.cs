using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exporter;

public static class ExportScanner
{
    public static List<ProjectExport> GetExportInfo()
    {
        var results = new List<ProjectExport>();

        string[] directories = Directory.GetDirectories(CommonInfo.SolutionDirectory);

        foreach (string directory in directories)
        {
            string projectName = Path.GetFileName(directory);

            if (!projectName.StartsWith("AreYouFruits"))
            {
                continue;
            }

            string releaseDirectory = Path.Combine(directory, "bin", "Release");

            string frameworkDirectory = GetFrameworkDirectory(releaseDirectory);

            var filePaths = new List<string>();

            foreach (string exportedFileExtension in Properties.ExportedFileExtensions)
            {
                filePaths.Add(Path.Combine(frameworkDirectory, projectName) + "." + exportedFileExtension);
            }
            
            results.Add(new ProjectExport(projectName, filePaths));
        }

        return results;
    }

    private static string GetFrameworkDirectory(string releaseDirectory)
    {
        try
        {
            return Directory.GetDirectories(releaseDirectory)
                .Single(d => Properties.SupportedFrameworks.Contains(Path.GetFileName(d)));
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException($"There should be one and only supported platform in {releaseDirectory}");
        }
    }
}