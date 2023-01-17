using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AreYouFruits.DependencyInjection.ContextInitialization
{
    public static class ContextInitializer
    {
        private static readonly object Locker = new object();

        private static volatile bool _isInitialized;

        public static void TryInitialize()
        {
            if (_isInitialized)
            {
                return;
            }

            lock (Locker)
            {
                if (_isInitialized)
                {
                    return;
                }

                Initialize();

                _isInitialized = true;
            }
        }

        private static void Initialize()
        {
            var exceptions = new List<Exception>();
            
            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

            MethodInfo[] potentialMethodInfos = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.Namespace?.StartsWith("Unity.") != true)
                .Where(type => type.Namespace?.StartsWith("UnityEngine.") != true)
                .Where(type => type.Namespace?.StartsWith("UnityEditor.") != true)
                .SelectMany(type => type.GetMethods(bindingFlags))
                .ToArray();

            foreach (MethodInfo methodInfo in potentialMethodInfos)
            {
                if (methodInfo.ContainsGenericParameters || methodInfo.GetParameters().Any())
                {
                    continue;
                }

                if (methodInfo.GetCustomAttribute<ContextInitializerAttribute>() is null)
                {
                    continue;
                }

                try
                {
                    methodInfo.Invoke(null, null);
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
    }
}