using System.Collections.Generic;
using System.IO;

namespace Exporter;

public static class FilesCopier
{
    public static void CopyFiles(IEnumerable<ProjectExport> projectExports)
    {
        foreach (ProjectExport projectExport in projectExports)
        {
            string projectName = projectExport.ProjectName;
            
            if (projectName.StartsWith("AreYouFruits") && Properties.RemoveAreYouFruitsPrefixInExportFolders)
            {
                projectName = projectName.Substring("AreYouFruits.".Length);
            }
            
            string projectDirectory = Path.Combine(CommonInfo.ExportDirectoryPath, projectName);

            Directory.CreateDirectory(projectDirectory);

            foreach (string filePath in projectExport.FilePaths)
            {
                string destinationFilePath = Path.Combine(projectDirectory, Path.GetFileName(filePath));
                
                File.Copy(filePath, destinationFilePath);
            }
        }
    }
}