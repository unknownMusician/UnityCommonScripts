using System;
using System.Collections.Generic;
using Exporter;

List<ProjectExport> projectExports = ExportScanner.GetExportInfo();

ExportDirectoryPreparer.PrepareExportDirectory();

FilesCopier.CopyFiles(projectExports);

AdditionalDirectoriesCopier.CopyAdditionalDirectories();

Console.WriteLine($"Copied into {CommonInfo.ExportDirectoryPath}:");

foreach (ProjectExport projectExport in projectExports)
{
    Console.WriteLine("- " + projectExport.ProjectName);
}

foreach (string additionalDirectory in Properties.AdditionalDirectoryNames)
{
    Console.WriteLine("- [additional] " + additionalDirectory);
}