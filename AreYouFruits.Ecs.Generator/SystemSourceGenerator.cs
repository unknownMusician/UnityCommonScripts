using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace AreYouFruits.Ecs.Analyzer;

[Generator]
public class SystemSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
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

                if (attributeName is "AreYouFruits.Ecs.EcsSystemAttribute")
                {
                    return classDeclarationSyntax;
                }
            }
        }

        return null;
    }

    private static void GenerateCode(
        SourceProductionContext ctx,
        (Compilation Compilation, ImmutableArray<MethodDeclarationSyntax> Declarations) t
    )
    {
        GenerateCode(ctx, t.Compilation, t.Declarations);
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

            var systemParamDatas = new List<SystemParamData>();

            foreach (var parameter in methodSymbol.Parameters)
            {
                if (parameter.Type is not INamedTypeSymbol namedTypeSymbol)
                {
                    return;
                }

                var fullTypeName = GetFullTypeName(namedTypeSymbol);

                var typeInterfaces = parameter.Type.AllInterfaces;
                
                if (typeInterfaces.Any(i => GetFullTypeName(i) == "global::AreYouFruits.Ecs.IResource"))
                {
                    systemParamDatas.Add(new SystemParamData
                    {
                        VariableName = parameter.Name,
                        VariableCreationExpression = $"ctx.Resources.Get<{fullTypeName}>()",
                    });
                }
                else if (fullTypeName.StartsWith("global::AreYouFruits.Ecs.EventsHolderAccess<"))
                {
                    var typeArgumentName = GetFullTypeName(namedTypeSymbol.TypeArguments[0]);

                    systemParamDatas.Add(new SystemParamData
                    {
                        VariableName = parameter.Name,
                        VariableCreationExpression = $"ctx.Events.Of<{typeArgumentName}>()",
                    });
                }
            }

            var callMethodParams = string.Join(", ", systemParamDatas.Select(p => p.VariableName));

            var variables = new StringBuilder();
            
            foreach (var systemParamData in systemParamDatas)
            {
                variables.Append($"            var @{systemParamData.VariableName} = {systemParamData.VariableCreationExpression};\n");
            }
            
            // Build up the source code
            var code = $@"// <auto-generated/>

namespace {namespaceName}
{{
    partial class {className} : global::AreYouFruits.Ecs.ISystem
    {{
        void global::AreYouFruits.Ecs.ISystem.Execute(global::AreYouFruits.Ecs.SystemContext ctx)
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