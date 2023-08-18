using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AreYouFruits.InitializerGeneration.Generator
{
    [Generator]
    public sealed class InitializerGenerator : ISourceGenerator
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
                
                foreach (SyntaxTree syntaxTree in context.Compilation.SyntaxTrees)
                {
                    foreach (SyntaxNode syntaxNode in syntaxTree.GetRoot().DescendantNodes())
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
                context.AddSource($"{nameof(InitializerGenerator)}.Error.g.cs", $@"
namespace AreYouFruits.InitializerGeneration.Generator
{{
    public static class InitializerGeneratorSourceGeneratorError
    {{
        public const string Exception = @""{exception.ToString()}"";
    }}
}}");
            }
        }

        private bool ReferencesGeneratorAssembly(in GeneratorExecutionContext context)
        {
            foreach (IAssemblySymbol sourceModuleReferencedAssemblySymbol in context.Compilation.SourceModule
                .ReferencedAssemblySymbols)
            {
                if (sourceModuleReferencedAssemblySymbol.Name is "AreYouFruits.InitializerGeneration")
                {
                    return true;
                }
            }

            return false;
        }

        private void GenerateFor(TypeDeclarationSyntax typeDeclarationSyntax, in GeneratorExecutionContext context)
        {
            int suitableFields = 0;
            
            if (!CanGenerateForType(typeDeclarationSyntax))
            {
                return;
            }

            var fields = new List<FieldDeclarationSyntax>();

            foreach (MemberDeclarationSyntax memberDeclarationSyntax in typeDeclarationSyntax.Members)
            {
                if (memberDeclarationSyntax is not FieldDeclarationSyntax fieldDeclarationSyntax)
                {
                    continue;
                }
                
                if (!ShouldGenerateForField(fieldDeclarationSyntax))
                {
                    continue;
                }

                suitableFields++;
                
                fields.Add(fieldDeclarationSyntax);
            }

            if (!fields.Any())
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

            bool hasNamespace = false;

            string indent = string.Empty;
            
            foreach (UsingDirectiveSyntax usingDirectiveSyntax in GetRoot(type).Usings)
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

            string initializersParameters = string.Join(", ", GetInitializerParameters(fields));

            source.AppendLine($"{indent}{type.Modifiers.ToString()} {type.Keyword.ToString()} {type.Identifier.ToString()}");
            source.AppendLine($"{indent}{{");
            source.AppendLine($"{indent}    public void Initialize({initializersParameters})");
            source.AppendLine($"{indent}    {{");
            
            foreach (string initializationExpression in GetInitializationExpressions(fields))
            {
                source.AppendLine($"{indent}        {initializationExpression}");
            }
            
            source.AppendLine($"{indent}    }}");
            source.AppendLine($"{indent}}}");

            if (hasNamespace)
            {
                source.AppendLine("}");
            }

            context.AddSource($"InitializerGenerator.{type.Identifier.ToString()}.g.cs", source.ToString());
        }

        private CompilationUnitSyntax GetRoot(SyntaxNode syntaxNode)
        {
            while (syntaxNode is not CompilationUnitSyntax)
            {
                syntaxNode = syntaxNode.Parent;
            }

            return (CompilationUnitSyntax)syntaxNode;
        }

        private IEnumerable<string> GetInitializerParameters(IEnumerable<FieldDeclarationSyntax> fields)
        {
            foreach (FieldDeclarationSyntax fieldDeclarationSyntax in fields)
            {
                VariableDeclarationSyntax declaration = fieldDeclarationSyntax.Declaration;

                foreach (VariableDeclaratorSyntax variableDeclaratorSyntax in declaration.Variables)
                {
                    string identifier = variableDeclaratorSyntax.Identifier.ToString();

                    string parameterName = char.ToLower(identifier[0]) + identifier.Substring(1);

                    yield return $"{declaration.Type} {parameterName}";
                }
            }
        }

        private IEnumerable<string> GetInitializationExpressions(IEnumerable<FieldDeclarationSyntax> fields)
        {
            foreach (FieldDeclarationSyntax fieldDeclarationSyntax in fields)
            {
                VariableDeclarationSyntax declaration = fieldDeclarationSyntax.Declaration;

                foreach (VariableDeclaratorSyntax variableDeclaratorSyntax in declaration.Variables)
                {
                    string identifier = variableDeclaratorSyntax.Identifier.ToString();

                    string parameterName = char.ToLower(identifier[0]) + identifier.Substring(1);

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
            foreach (AttributeListSyntax attributeListSyntax in fieldDeclarationSyntax.AttributeLists)
            {
                foreach (AttributeSyntax attributeSyntax in attributeListSyntax.Attributes)
                {
                    if (attributeSyntax.ToString() is "GenerateInitializer" or "GenerateInitializerAttribute")
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}