using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace AreYouFruits.ConstructorGeneration.Generator
{
    [DiagnosticAnalyzer("CSharp")]
    public sealed class ConstructorGeneratorAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => Diagnostics.All;
        
        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            
            context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.StructDeclaration, SyntaxKind.ClassDeclaration);
        }

        private void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
        {
            var typeDeclarationSyntax = (TypeDeclarationSyntax)context.Node;

            if (!ShouldGenerateConstructorFor(typeDeclarationSyntax))
            {
                return;
            }
            
            if (!typeDeclarationSyntax.Modifiers.Any(SyntaxKind.PartialKeyword))
            {
                context.ReportDiagnostic(Diagnostic.Create(Diagnostics.TypeNeedsPartial, typeDeclarationSyntax.Identifier.GetLocation()));
            }
        }

        private bool ShouldGenerateConstructorFor(TypeDeclarationSyntax typeDeclarationSyntax)
        {
            foreach (var memberDeclarationSyntax in typeDeclarationSyntax.Members)
            {
                if (memberDeclarationSyntax is not FieldDeclarationSyntax fieldDeclarationSyntax)
                {
                    continue;
                }
                
                foreach (var attributeListSyntax in fieldDeclarationSyntax.AttributeLists)
                {
                    foreach (var attributeSyntax in attributeListSyntax.Attributes)
                    {
                        if (attributeSyntax.Name.ToString() is "GenerateConstructor" or "GenerateConstructorAttribute")
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
