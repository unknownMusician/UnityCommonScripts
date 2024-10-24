using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AreYouFruits.DependencyInjection.KeyedTypeResolvers;
using AreYouFruits.DependencyInjection.TypeResolvers;

namespace AreYouFruits.DependencyInjection.ContextInitialization
{
    public static class MethodsWithInitializerAttributeCaller
    {
        private const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        public static void Call(IKeyedDiContainer container, ContextType contextType)
        {
            var exceptions = new List<Exception>();

            var potentialMethodInfos = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => !IsUnityType(type))
                .SelectMany(type => type.GetMethods(Flags));

            foreach (var methodInfo in potentialMethodInfos)
            {
                if (!IsValid(methodInfo, out var caller, contextType))
                {
                    continue;
                }
                
                try
                {
                    caller(container);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }

        private static bool IsValid(MethodInfo method, out Action<IKeyedDiContainer> caller, ContextType contextType)
        {
            if (method.ContainsGenericParameters)
            {
                caller = null!;
                return false;
            }

            var attribute = method.GetCustomAttribute<ContextInitializerAttribute>();

            if (attribute is null || (attribute.ContextType != contextType))
            {
                caller = null!;
                return false;
            }

            var parameters = method.GetParameters();
            
            if (parameters.Length > 1)
            {
                caller = _ => throw new Exception($"The method {method.Name} contains invalid parameters.");
                return true;
            }

            var parameterType = parameters[0].ParameterType;

            var keyIsNull = attribute.Key is null;

            if (!keyIsNull && (parameterType == typeof(IDiContainer)))
            {
                caller = container => method.Invoke(null, new object[] { container.For(attribute.Key!) });
                return true;
            }

            if (keyIsNull && ((parameterType == typeof(IDiContainer)) || (parameterType == typeof(IKeyedDiContainer))))
            {
                caller = container => method.Invoke(null, new object[] { container });
                return true;
            }
            
            caller = _ => throw new Exception($"The method {method.Name} contains invalid parameters.");
            return true;
        }

        private static bool IsUnityType(Type type)
        {
            var typeNamespace = type.Namespace;

            if (typeNamespace is null)
            {
                return false;
            }
            
            return typeNamespace.StartsWith("Unity.") ||
                typeNamespace.StartsWith("UnityEngine.") ||
                typeNamespace.StartsWith("UnityEditor.");
        }
    }
}