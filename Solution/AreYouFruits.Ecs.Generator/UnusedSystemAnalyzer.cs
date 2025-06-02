using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace AreYouFruits.Ecs.Analyzer;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class UnusedSystemAnalyzer : DiagnosticAnalyzer
{
    private static readonly DiagnosticDescriptor Rule = new(
        id: "AYFECS001",
        title: "Unused ISystem Implementation",
        messageFormat: "Class '{0}' implements ISystem but is never used."
        + " If this is intentional, use [IntentionallyUnused] attribute.",
        category: "Usage",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true
    );

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        // Register action to analyze named type symbols (classes, interfaces, etc.)
        context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
    }

    private static void AnalyzeSymbol(SymbolAnalysisContext context)
    {
        var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;

        // Check if the class implements ISystem
        if (namedTypeSymbol.TypeKind != TypeKind.Class)
        {
            return;
        }

        var iSystemInterface = context.Compilation.GetTypeByMetadataName("AreYouFruits.Ecs.ISystem");
        if (iSystemInterface == null || !namedTypeSymbol.AllInterfaces.Contains(iSystemInterface))
        {
            return;
        }

        // Skip if it has [IntentionallyUnusedAttribute]
        var intentionallyUnusedAttr =
            context.Compilation.GetTypeByMetadataName("AreYouFruits.Ecs.IntentionallyUnusedAttribute");
        if (intentionallyUnusedAttr != null &&
            namedTypeSymbol.GetAttributes().Any(attr =>
                SymbolEqualityComparer.Default.Equals(attr.AttributeClass, intentionallyUnusedAttr)))
        {
            return;
        }

        try
        {
            // Check references
            if (IsSymbolReferenced(namedTypeSymbol, context.Compilation))
            {
                return;
            }

            // If not used, report a diagnostic
            var diagnostic = Diagnostic.Create(Rule, namedTypeSymbol.Locations[0], namedTypeSymbol.Name);
            context.ReportDiagnostic(diagnostic);
        }
        catch (Exception exception)
        {
            var diagnostic = Diagnostic.Create(Rule, namedTypeSymbol.Locations[0], exception.ToString());
            context.ReportDiagnostic(diagnostic);
        }
    }

    private static bool IsSymbolReferenced(INamedTypeSymbol typeSymbol, Compilation compilation)
    {
        foreach (var syntaxTree in compilation.SyntaxTrees)
        {
            var semanticModel = compilation.GetSemanticModel(syntaxTree);
            var root = syntaxTree.GetRoot();

            // Look for object creations or references of the class
            var references = root.DescendantNodes()
                .Select(node => semanticModel.GetSymbolInfo(node).Symbol)
                .Where(symbol =>
                    symbol != null && SymbolEqualityComparer.Default.Equals(symbol, typeSymbol));

            if (references.Any())
            {
                return true;
            }
        }

        return false;
    }
}