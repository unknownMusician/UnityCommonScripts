using System;
using Exporter;

var projectExports = ExportScanner.GetExportInfo();

ExportDirectoryPreparer.PrepareExportDirectory();

FilesCopier.CopyFiles(projectExports);

Console.WriteLine($"Copied into {CommonInfo.ExportDirectoryPath}:");

foreach (var projectExport in projectExports)
{
    Console.WriteLine("- " + projectExport.ProjectName);
}