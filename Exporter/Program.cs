using System;
using System.Collections.Generic;
using System.Diagnostics;
using Exporter;

var projectExports = ExportScanner.GetExportInfo();

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

Process.Start("explorer.exe", CommonInfo.ExportDirectoryPath);