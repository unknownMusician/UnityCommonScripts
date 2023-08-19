using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace AreYouFruits.ConstructorGeneration.Generator
{
    public static class Diagnostics
    {
        public static DiagnosticDescriptor TypeNeedsPartial { get; } = new(
            id: "CtorGen_0",
            title: "Type needs to be partial",
            messageFormat: "Type needs to be marked partial to support SourceGenerator.",
            category: "ConstructorGeneration",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true
        );
        
        public static ImmutableArray<DiagnosticDescriptor> All { get; } = new[]
        {
            TypeNeedsPartial,
        }.ToImmutableArray();
    }
}
