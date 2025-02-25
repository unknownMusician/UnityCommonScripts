﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AreYouFruits.ToStringGeneration.Generator
{
    [Generator]
    public class ToStringSourceGenerator : ISourceGenerator
        // todo: refactor and optimize
    {
        public void Initialize(GeneratorInitializationContext context) { }

        public void Execute(GeneratorExecutionContext context)
        {
            try
            {
                if (!ReferencesGeneratorAssembly(context))
                {
                    return;
                }
                
                foreach (var syntaxTree in context.Compilation.SyntaxTrees)
                {
                    foreach (var syntaxNode in syntaxTree.GetRoot().DescendantNodes())
                    {
                        if (syntaxNode is not TypeDeclarationSyntax typeDeclarationSyntax)
                        {
                            continue;
                        }
                        
                        GenerateFor(typeDeclarationSyntax, context);
                    }
                }
            }
            catch (Exception exception)
            {
                context.AddSource($"{nameof(ToStringSourceGenerator)}.Error.g.cs", $@"
namespace AreYouFruits.ToStringGeneration.Generator
{{
    public static class ToStringSourceGeneratorError
    {{
        public const string Exception = @""{exception.ToString()}"";
    }}
}}");
            }
        }

        private bool ReferencesGeneratorAssembly(in GeneratorExecutionContext context)
        {
            foreach (var sourceModuleReferencedAssemblySymbol in context.Compilation.SourceModule
                .ReferencedAssemblySymbols)
            {
                if (sourceModuleReferencedAssemblySymbol.Name is "AreYouFruits.ToStringGeneration")
                {
                    return true;
                }
            }

            return false;
        }

        private void GenerateFor(TypeDeclarationSyntax typeDeclarationSyntax, in GeneratorExecutionContext context)
        {
            if (!ShouldGenerateToStringFor(typeDeclarationSyntax, context)
             || !CanGenerateToStringFor(typeDeclarationSyntax, context))
            {
                return;
            }
            
            if (typeDeclarationSyntax.Parent is not null
             && typeDeclarationSyntax.Parent is not NamespaceDeclarationSyntax)
            {
                return;
            }

            StringBuilder sourceBuilder = new();

            var indent = string.Empty;

            sourceBuilder.AppendLine("using AreYouFruits.ToStringGeneration;");
            sourceBuilder.AppendLine("");
            
            if (typeDeclarationSyntax.Parent is NamespaceDeclarationSyntax namespaceDeclarationSyntax)
            {
                sourceBuilder.AppendLine($"namespace {namespaceDeclarationSyntax.Name.ToString()}");
                sourceBuilder.Append("{");
                indent = "    ";
            }
            
            sourceBuilder.Append(@$"
{indent}{typeDeclarationSyntax.Modifiers.ToString()} {typeDeclarationSyntax.Keyword.ToString()} {typeDeclarationSyntax.Identifier.ToString()}
{indent}{{
{indent}    public override string ToString()
{indent}    {{
{indent}        return {GenerateToString(GetToStringMembers(typeDeclarationSyntax, context), typeDeclarationSyntax)};
{indent}    }}
{indent}}}");
            if (typeDeclarationSyntax.Parent is NamespaceDeclarationSyntax)
            {
                sourceBuilder.Append("\n}");
            }

            context.AddSource($"{nameof(ToStringSourceGenerator)}.{typeDeclarationSyntax.Identifier.ToString()}.g.cs", sourceBuilder.ToString());
        }

        private string GenerateToString(IEnumerable<string> toStringClassMembers, TypeDeclarationSyntax typeDeclarationSyntax)
        {
            var members = toStringClassMembers.Any() switch
            {
                true => ' ' + string.Join("; ", toStringClassMembers.Select(t => $"{t}: {{{t}.ToStringUniversal()}}")) + ' ',
                false => " ",
            };
            
            return $"$\"{typeDeclarationSyntax.Identifier} {{{{{members}}}}}\"";
        }

        private List<string> GetToStringMembers(
            TypeDeclarationSyntax typeDeclarationSyntax,
            in GeneratorExecutionContext context
        )
        {
            var results = new List<string>();
            
            foreach (var memberDeclarationSyntax in typeDeclarationSyntax.Members)
            {
                if (!IsMemberPublic(memberDeclarationSyntax, typeDeclarationSyntax))
                {
                    continue;
                }
                
                if (memberDeclarationSyntax is FieldDeclarationSyntax fieldDeclarationSyntax)
                {
                    foreach (var variableDeclaratorSyntax in fieldDeclarationSyntax.Declaration.Variables)
                    {
                        results.Add(variableDeclaratorSyntax.Identifier.ToString());
                    }

                    continue;
                }

                if (memberDeclarationSyntax is PropertyDeclarationSyntax propertyDeclarationSyntax)
                {
                    if (propertyDeclarationSyntax.AccessorList is not { } accessorList
                     || accessorList.Accessors.Any(a => a.Keyword.IsKind(SyntaxKind.GetKeyword)))
                    {
                        var identifier = propertyDeclarationSyntax.Identifier.ToString();
                        
                        results.Add(identifier);
                    }
                }
            }

            return results;
        }

        private bool IsMemberPublic(MemberDeclarationSyntax memberDeclarationSyntax, TypeDeclarationSyntax typeDeclarationSyntax)
        {
            if (typeDeclarationSyntax is ClassDeclarationSyntax)
            {
                return memberDeclarationSyntax.Modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword));
            }

            if (typeDeclarationSyntax is StructDeclarationSyntax)
            {
                return !memberDeclarationSyntax.Modifiers.Any(m
                    => m.IsKind(SyntaxKind.PrivateKeyword)
                 || m.IsKind(SyntaxKind.ProtectedKeyword)
                 || m.IsKind(SyntaxKind.InternalKeyword));
            }

            throw new NotSupportedException();
        }

        private bool ShouldGenerateToStringFor(
            TypeDeclarationSyntax typeDeclarationSyntax,
            in GeneratorExecutionContext context
        )
        {
            foreach (var attributeListSyntax in typeDeclarationSyntax.AttributeLists)
            {
                var symbol = GetDeclaredSymbol(attributeListSyntax.Parent!, context.Compilation);

                foreach (var attributeData in symbol.GetAttributes())
                {
                    if (attributeData.AttributeClass!.Name == "GenerateToStringAttribute")
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CanGenerateToStringFor(
            TypeDeclarationSyntax typeDeclarationSyntax,
            in GeneratorExecutionContext context
        )
        {
            if (!typeDeclarationSyntax.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword)))
            {
                return false;
            }

            foreach (var memberDeclarationSyntax in typeDeclarationSyntax.Members)
            {
                if (memberDeclarationSyntax is not MethodDeclarationSyntax methodDeclarationSyntax)
                {
                    continue;
                }

                if (methodDeclarationSyntax.Identifier.ToString() == "ToString")
                {
                    return false;
                }
            }

            return true;
        }

        private static ISymbol GetDeclaredSymbol(SyntaxNode node, Compilation compilation)
        {
            return compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
        }
    }
}