using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace AreYouFruits.InitializerGeneration.Generator
{
    public static class Diagnostics
    {
        public static DiagnosticDescriptor TypeNeedsPartial { get; } = new(
            id: "InitGen_0",
            title: "Type needs to be partial",
            messageFormat: "Type needs to be marked partial to support SourceGenerator.",
            category: "InitializerGeneration",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true
        );
        
        public static ImmutableArray<DiagnosticDescriptor> All { get; } = new[]
        {
            TypeNeedsPartial,
        }.ToImmutableArray();
    }
}
