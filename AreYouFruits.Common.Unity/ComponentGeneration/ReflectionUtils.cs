using System;
using System.Linq;
using System.Text;

namespace AreYouFruits.Common.ComponentGeneration
{
    public static class ReflectionUtils
    {
        public static Type[] AllTypes => AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .ToArray();
        
        
        public static string GetReadableName(this Type type)
        {
            var retType = new StringBuilder();

            string typeName = type.Name;

            if (type.IsNested)
            {
                typeName = typeName.Replace('+', '.');
            }
            
            if (type.IsGenericType)
            {
                string[] parentType = typeName.Split('`');
                // We will build the type here.
                Type[] arguments = type.GetGenericArguments();

                string[] argumentsArray = arguments.Select(GetReadableName).ToArray();

                string argumentsAsString = argumentsArray.Aggregate((a, b) => $"{a}, {b}");  
                
                if (argumentsArray.Length > 0)
                {
                    retType.Append(parentType[0]);
                    retType.Append('<');
                    retType.Append(argumentsAsString);
                    retType.Append('>');
                }
            }
            else
            {
                return type.ToString();
            }

            return retType.ToString();
        }
    }
}
