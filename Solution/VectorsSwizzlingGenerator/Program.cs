using AreYouFruits.VectorsSwizzling.Generator;

var dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName;

var vectorsSwizzlingDir = Path.Combine(dir, "Assets", "package", "Runtime", "VectorsSwizzling");

if (!Directory.Exists(vectorsSwizzlingDir))
{
    Directory.CreateDirectory(vectorsSwizzlingDir);
}

foreach (var source in VectorsSwizzlingProvider.GenerateSwizzlings())
{
    var path = Path.Combine(vectorsSwizzlingDir, source.Name);
    
    File.WriteAllText(path, source.Content);
}