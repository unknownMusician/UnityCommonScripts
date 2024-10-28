using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace AreYouFruits.Events.Generator;

/// <summary>
/// A sample source generator that creates a custom report based on class properties. The target class should be annotated with the 'Generators.ReportAttribute' attribute.
/// When using the source code as a baseline, an incremental source generator is preferable because it reduces the performance overhead.
/// </summary>
[Generator]
public class EventHandlerSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Filter classes annotated with the [Report] attribute. Only filtered Syntax Nodes can trigger code generation.
        var provider = context.SyntaxProvider
            .CreateSyntaxProvider(
                (s, _) => s is MethodDeclarationSyntax,
                (ctx, _) => GetDeclarationForSourceGen(ctx)
            )
            .Where(t => t is not null)
            .Select((t, _) => t);

        // Generate the source code.
        context.RegisterSourceOutput(context.CompilationProvider.Combine(provider.Collect()), GenerateCode);
    }

    /// <summary>
    /// Checks whether the Node is annotated with the [Report] attribute and maps syntax context to the specific node type (ClassDeclarationSyntax).
    /// </summary>
    /// <param name="context">Syntax context, based on CreateSyntaxProvider predicate</param>
    /// <returns>The specific cast and whether the attribute was found.</returns>
    private static MethodDeclarationSyntax? GetDeclarationForSourceGen(
        GeneratorSyntaxContext context)
    {
        var classDeclarationSyntax = (MethodDeclarationSyntax)context.Node;

        // Go through all attributes of the class.
        foreach (AttributeListSyntax attributeListSyntax in classDeclarationSyntax.AttributeLists)
        {
            foreach (AttributeSyntax attributeSyntax in attributeListSyntax.Attributes)
            {
                if (context.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
                {
                    continue;
                }

                var attributeName = attributeSymbol.ContainingType.ToDisplayString();

                if (attributeName is "AreYouFruits.Events.EventHandlerAttribute")
                {
                    return classDeclarationSyntax;
                }
            }
        }

        return null;
    }

    private static void GenerateCode(
        SourceProductionContext ctx,
        (Compilation Left, ImmutableArray<MethodDeclarationSyntax> Right) t
    )
    {
        GenerateCode(ctx, t.Left, t.Right);
    }

    /// <summary>
    /// Generate code action.
    /// It will be executed on specific nodes (ClassDeclarationSyntax annotated with the [Report] attribute) changed by the user.
    /// </summary>
    /// <param name="context">Source generation context used to add source files.</param>
    /// <param name="compilation">Compilation used to provide access to the Semantic Model.</param>
    /// <param name="declarations">Nodes annotated with the [Report] attribute that trigger the generate action.</param>
    private static void GenerateCode(
        SourceProductionContext context,
        Compilation compilation,
        ImmutableArray<MethodDeclarationSyntax> declarations
    )
    {
        // Go through all filtered class declarations.
        foreach (var declaration in declarations)
        {
            // We need to get semantic model of the class to retrieve metadata.
            var semanticModel = compilation.GetSemanticModel(declaration.SyntaxTree);

            // Symbols allow us to get the compile-time information.
            if (semanticModel.GetDeclaredSymbol(declaration) is not IMethodSymbol methodSymbol)
            {
                continue;
            }

            var containingType = methodSymbol.ContainingType;

            var namespaceName = containingType.ContainingNamespace.ToDisplayString();

            var className = containingType.Name;

            var eventParameter = methodSymbol.Parameters[0];

            var eventType = GetFullTypeName(eventParameter.Type);

            var resources = methodSymbol.Parameters.Skip(1).Select(p => (GetFullTypeName(p.Type), p.Name)).ToArray();

            var callMethodParams = $"@{eventParameter.Name}";
            
            foreach (var (_, resourceName) in resources)
            {
                callMethodParams += $", @{resourceName}";
            }

            var variables = "";
            
            foreach (var (resourceType, resourceName) in resources)
            {
                variables += $"            var @{resourceName} = global::AreYouFruits.Events.ResourcesLocator.Get<{resourceType}>();\n";
            }
            
            // Build up the source code
            var code = $@"// <auto-generated/>

namespace {namespaceName}
{{
    partial class {className} : global::AreYouFruits.Events.IEventHandler<{eventType}>
    {{
        void global::AreYouFruits.Events.IEventHandler<{eventType}>.Handle({eventType} @{eventParameter.Name})
        {{
{variables}
            {methodSymbol.Name}({callMethodParams});
        }}
    }}
}}
";

            // Add the source code to the compilation.
            context.AddSource($"{className}.g.cs", SourceText.From(code, Encoding.UTF8));
        }
    }

    private static string GetFullTypeName(ITypeSymbol typeSymbol)
    {
        var fullName = typeSymbol.Name;

        ISymbol symbol = typeSymbol;

        while (symbol.ContainingNamespace is { } containingNamespace)
        {
            if (containingNamespace.IsGlobalNamespace)
            {
                fullName = $"global::{fullName}";
                break;
            }

            fullName = $"{containingNamespace.Name}.{fullName}";
            symbol = symbol.ContainingNamespace;
        }

        return fullName;
    }
}