using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace AreYouFruits.VectorsSwizzling
{
    [Generator]
    public class VectorsSwizzlingGenerator : ISourceGenerator
        // todo: refactor and optimize
    {
        private readonly List<Source> sources = VectorsSwizzlingProvider.GenerateSwizzlings();
        
        public void Initialize(GeneratorInitializationContext context) { }

        public void Execute(GeneratorExecutionContext context)
        {
            foreach (Source source in sources)
            {
                context.AddSource(source.Name, source.Content);
            }
        }
    }
}