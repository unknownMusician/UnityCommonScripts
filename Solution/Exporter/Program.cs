using System;
using Exporter;

var projectExports = ExportScanner.GetExportInfo();

Console.WriteLine(CommonInfo.SolutionDirectory);
Console.WriteLine(CommonInfo.ExportDirectoryPath);

return;

ExportDirectoryPreparer.PrepareExportDirectory();

FilesCopier.CopyFiles(projectExports);

AdditionalDirectoriesCopier.CopyAdditionalDirectories();

Console.WriteLine($"Copied into {CommonInfo.ExportDirectoryPath}:");

foreach (var projectExport in projectExports)
{
    Console.WriteLine("- " + projectExport.ProjectName);
}

foreach (var additionalDirectory in Properties.AdditionalDirectoryNames)
{
    Console.WriteLine("- [additional] " + additionalDirectory);
}