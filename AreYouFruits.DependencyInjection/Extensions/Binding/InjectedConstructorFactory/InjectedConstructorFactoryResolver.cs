using System;
using System.Reflection;
using AreYouFruits.DependencyInjection.Resolvers;
using AreYouFruits.DependencyInjection.TypeResolvers;

namespace AreYouFruits.DependencyInjection.Extensions.Binding.InjectedConstructorFactory
{
    public sealed class InjectedConstructorFactoryResolver<TSource> : IResolver<TSource>
    {
        private readonly ConstructorInfo constructor;

        public InjectedConstructorFactoryResolver()
        {
            ConstructorInfo[] constructors = typeof(TSource).GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            if (constructors.Length != 1)
            {
                throw new ArgumentOutOfRangeException($"Type {typeof(TSource).FullName} should contain 1 public constructor to be injected. {constructors.Length.ToString()} found.");
            }

            constructor = constructors[0];
        }

        public TSource Resolve(IDiByTypeResolver resolver)
        {
            if (resolver is null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }

            ParameterInfo[] parameterInfos = constructor.GetParameters();

            object[] parameters = new object[parameterInfos.Length];

            for (int i = 0; i < parameterInfos.Length; i++)
            {
                parameters[i] = resolver.Resolve(parameterInfos[i].ParameterType);
            }
            
            return (TSource)constructor.Invoke(parameters);
        }
    }
}
