﻿using System.Collections.Generic;
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

        context.RegisterSourceOutput(context.CompilationProvider.Combine(provider.Collect()), GenerateCode);
    }

    private static MethodDeclarationSyntax? GetDeclarationForSourceGen(
        GeneratorSyntaxContext context)
    {
        var classDeclarationSyntax = (MethodDeclarationSyntax)context.Node;

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

    private static void GenerateCode(
        SourceProductionContext context,
        Compilation compilation,
        ImmutableArray<MethodDeclarationSyntax> declarations
    )
    {
        foreach (var declaration in declarations)
        {
            var semanticModel = compilation.GetSemanticModel(declaration.SyntaxTree);

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
                        DataUsageQueryPart = $".Resource<{fullTypeName}>()",
                    });
                }
                else if (fullTypeName == "global::AreYouFruits.Ecs.EventsHolderAccess")
                {
                    var typeArgumentName = GetFullTypeName(namedTypeSymbol.TypeArguments[0]);

                    systemParamDatas.Add(new SystemParamData
                    {
                        VariableName = parameter.Name,
                        VariableCreationExpression = $"ctx.Events.Of<{typeArgumentName}>()",
                        DataUsageQueryPart = $".Event<{typeArgumentName}>()",
                    });
                }
                else
                {
                    systemParamDatas.Add(new SystemParamData
                    {
                        VariableName = fullTypeName,
                        VariableCreationExpression = $"",
                        DataUsageQueryPart = $"",
                    });
                }
            }

            var callMethodParams = string.Join(", ", systemParamDatas.Select(p => p.VariableName));

            var variables = new StringBuilder();
            var dataUsageQuery = new StringBuilder();

            foreach (var systemParamData in systemParamDatas)
            {
                variables.Append($"            var @{systemParamData.VariableName} = {systemParamData.VariableCreationExpression};\n");
                dataUsageQuery.Append($"\n                {systemParamData.DataUsageQueryPart}");
            }

            var code = $@"// <auto-generated/>

namespace {namespaceName}
{{
    partial class {className} : global::AreYouFruits.Ecs.ISystem
    {{
        global::AreYouFruits.Nullability.Optional<global::AreYouFruits.Ecs.SystemDataUsage> global::AreYouFruits.Ecs.ISystem.TryGetDataUsage()
        {{
            return new global::AreYouFruits.Ecs.SystemDataUsage(){dataUsageQuery};
        }}

        void global::AreYouFruits.Ecs.ISystem.Execute(global::AreYouFruits.Ecs.SystemContext ctx)
        {{
{variables}
            {methodSymbol.Name}({callMethodParams});
        }}
    }}
}}
";

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