﻿using System.IO;

namespace Exporter;

public static class ExportDirectoryPreparer
{
    public static void PrepareExportDirectory()
    {
        string exportDirectoryPath = CommonInfo.ExportDirectoryPath;
        
        if (!Directory.Exists(exportDirectoryPath))
        {
            Directory.CreateDirectory(exportDirectoryPath);
        }
    }
}