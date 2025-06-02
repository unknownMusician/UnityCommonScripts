using System.Collections.Generic;

namespace Exporter;

public record ProjectExport(string ProjectName, IReadOnlyList<string> FilePaths);