using System.IO;

namespace Exporter
{
    public static class AdditionalDirectoriesCopier
    {
        public static void CopyAdditionalDirectories()
        {
            foreach (var additionalFolderName in Properties.AdditionalDirectoryNames)
            {
                var sourceDirectory = Path.Combine(CommonInfo.SolutionDirectory, additionalFolderName);
                var destinationDirectory = Path.Combine(CommonInfo.ExportDirectoryPath, additionalFolderName);

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

            var dirs = dir.GetDirectories();

            Directory.CreateDirectory(destinationDir);

            foreach (var file in dir.GetFiles())
            {
                var targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            if (recursive)
            {
                foreach (var subDir in dirs)
                {
                    var newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
    }
}
