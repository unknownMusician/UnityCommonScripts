using System.Collections.Generic;
using System.IO;

namespace Exporter;

public static class FilesCopier
{
    public static void CopyFiles(IEnumerable<ProjectExport> projectExports)
    {
        foreach (ProjectExport projectExport in projectExports)
        {
            string projectDirectory = Path.Combine(CommonInfo.ExportDirectoryPath, projectExport.ProjectName);

            Directory.CreateDirectory(projectDirectory);

            foreach (string filePath in projectExport.FilePaths)
            {
                string destinationFilePath = Path.Combine(projectDirectory, Path.GetFileName(filePath));
                
                File.Copy(filePath, destinationFilePath);
            }
        }
    }
}