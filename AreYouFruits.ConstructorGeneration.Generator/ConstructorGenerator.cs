using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AreYouFruits.ConstructorGeneration.Generator
{
    [Generator]
    public sealed class ConstructorGenerator : ISourceGenerator
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
                context.AddSource($"{nameof(ConstructorGenerator)}.Error.g.cs", $@"
namespace AreYouFruits.ConstructorGeneration.Generator
{{
    public static class ConstructorGeneratorSourceGeneratorError
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
                if (sourceModuleReferencedAssemblySymbol.Name is "AreYouFruits.ConstructorGeneration")
                {
                    return true;
                }
            }

            return false;
        }

        private void GenerateFor(TypeDeclarationSyntax typeDeclarationSyntax, in GeneratorExecutionContext context)
        {
            var fields = new List<FieldDeclarationSyntax>();

            foreach (var memberDeclarationSyntax in typeDeclarationSyntax.Members)
            {
                if (memberDeclarationSyntax is not FieldDeclarationSyntax fieldDeclarationSyntax)
                {
                    continue;
                }
                
                if (!ShouldGenerateForField(fieldDeclarationSyntax))
                {
                    continue;
                }

                fields.Add(fieldDeclarationSyntax);
            }

            if (!fields.Any())
            {
                return;
            }
            
            if (!CanGenerateForType(typeDeclarationSyntax))
            {
                return;
            }

            GenerateFor(typeDeclarationSyntax, fields, context);
        }

        private void GenerateFor(
            TypeDeclarationSyntax type,
            IEnumerable<FieldDeclarationSyntax> fields,
            in GeneratorExecutionContext context
        )
        {
            var source = new StringBuilder();

            var hasNamespace = false;

            var indent = string.Empty;
            
            foreach (var usingDirectiveSyntax in GetRoot(type).Usings)
            {
                source.AppendLine(usingDirectiveSyntax.ToString());
            }

            source.AppendLine();
            
            if (type.Parent is NamespaceDeclarationSyntax namespaceDeclarationSyntax)
            {
                hasNamespace = true;
                source.AppendLine($"namespace {namespaceDeclarationSyntax.Name.ToString()}");
                source.AppendLine("{");
                indent = "    ";
            }
            else if (type.Parent is not CompilationUnitSyntax)
            {
                return;
            }

            var constructorParameters = string.Join(", ", GetConstructorParameters(fields));

            source.AppendLine($"{indent}{type.Modifiers.ToString()} {type.Keyword.ToString()} {type.Identifier.ToString()}{type.TypeParameterList?.ToString()}");
            source.AppendLine($"{indent}{{");
            source.AppendLine($"{indent}    public {type.Identifier.ToString()}({constructorParameters})");

            if (ContainsParameterlessConstructor(type))
            {
                source.AppendLine($"{indent}        : this()");
            }
            
            source.AppendLine($"{indent}    {{");
            
            foreach (var initializationExpression in GetInitializationExpressions(fields))
            {
                source.AppendLine($"{indent}        {initializationExpression}");
            }
            
            source.AppendLine($"{indent}    }}");
            source.AppendLine($"{indent}}}");

            if (hasNamespace)
            {
                source.AppendLine("}");
            }

            var genericParametersPrefix = string.Empty;
            
            if (type.TypeParameterList is { } typeParameterList)
            {
                genericParametersPrefix = $".{typeParameterList.Parameters.Count}";
            }

            context.AddSource($"ConstructorGenerator.{type.Identifier.ToString()}{genericParametersPrefix}.g.cs", source.ToString());
        }

        private bool ContainsParameterlessConstructor(TypeDeclarationSyntax typeDeclarationSyntax)
        {
            foreach (var memberDeclarationSyntax in typeDeclarationSyntax.Members)
            {
                if (memberDeclarationSyntax is not ConstructorDeclarationSyntax constructorDeclarationSyntax)
                {
                    continue;
                }

                if (!constructorDeclarationSyntax.ParameterList.Parameters.Any())
                {
                    return true;
                }
            }
            
            return false;
        }

        private CompilationUnitSyntax GetRoot(SyntaxNode syntaxNode)
        {
            while (syntaxNode is not CompilationUnitSyntax)
            {
                syntaxNode = syntaxNode.Parent;
            }

            return (CompilationUnitSyntax)syntaxNode;
        }

        private IEnumerable<string> GetConstructorParameters(IEnumerable<FieldDeclarationSyntax> fields)
        {
            foreach (var fieldDeclarationSyntax in fields)
            {
                var declaration = fieldDeclarationSyntax.Declaration;

                foreach (var variableDeclaratorSyntax in declaration.Variables)
                {
                    var identifier = variableDeclaratorSyntax.Identifier.ToString();

                    var parameterName = char.ToLower(identifier[0]) + identifier.Substring(1);

                    yield return $"{declaration.Type} {parameterName}";
                }
            }
        }

        private IEnumerable<string> GetInitializationExpressions(IEnumerable<FieldDeclarationSyntax> fields)
        {
            foreach (var fieldDeclarationSyntax in fields)
            {
                var declaration = fieldDeclarationSyntax.Declaration;

                foreach (var variableDeclaratorSyntax in declaration.Variables)
                {
                    var identifier = variableDeclaratorSyntax.Identifier.ToString();

                    var parameterName = char.ToLower(identifier[0]) + identifier.Substring(1);

                    yield return $"this.{identifier} = {parameterName};";
                }
            }
        }

        private bool CanGenerateForType(TypeDeclarationSyntax typeDeclarationSyntax)
        {
            return typeDeclarationSyntax.Modifiers.Any(SyntaxKind.PartialKeyword);
        }

        private bool ShouldGenerateForField(FieldDeclarationSyntax fieldDeclarationSyntax)
        {
            foreach (var attributeListSyntax in fieldDeclarationSyntax.AttributeLists)
            {
                foreach (var attributeSyntax in attributeListSyntax.Attributes)
                {
                    if (attributeSyntax.ToString() is "GenerateConstructor" or "GenerateConstructorAttribute")
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static ISymbol GetDeclaredSymbol(SyntaxNode node, Compilation compilation)
        {
            return compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
        }
    }
}