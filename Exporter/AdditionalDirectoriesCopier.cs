using System.IO;

namespace Exporter
{
    public static class AdditionalDirectoriesCopier
    {
        public static void CopyAdditionalDirectories()
        {
            foreach (string additionalFolderName in Properties.AdditionalDirectoryNames)
            {
                string sourceDirectory = Path.Combine(CommonInfo.SolutionDirectory, additionalFolderName);
                string destinationDirectory = Path.Combine(CommonInfo.ExportDirectoryPath, additionalFolderName);

                CopyDirectory(sourceDirectory, destinationDirectory, recursive: true);
            }
        }
    
        private static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            Directory.CreateDirectory(destinationDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
    }
}
