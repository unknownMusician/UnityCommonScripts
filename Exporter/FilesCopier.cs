using System.Collections.Generic;
using System.IO;

namespace Exporter;

public static class FilesCopier
{
    public static void CopyFiles(IEnumerable<ProjectExport> projectExports)
    {
        foreach (var projectExport in projectExports)
        {
            var projectName = projectExport.ProjectName;
            
            if (projectName.StartsWith("AreYouFruits") && Properties.RemoveAreYouFruitsPrefixInExportFolders)
            {
                projectName = projectName.Substring("AreYouFruits.".Length);
            }
            
            var projectDirectory = Path.Combine(CommonInfo.ExportDirectoryPath, projectName);

            Directory.CreateDirectory(projectDirectory);

            foreach (var filePath in projectExport.FilePaths)
            {
                var destinationFilePath = Path.Combine(projectDirectory, Path.GetFileName(filePath));
                
                File.Copy(filePath, destinationFilePath);
            }
        }
    }
}