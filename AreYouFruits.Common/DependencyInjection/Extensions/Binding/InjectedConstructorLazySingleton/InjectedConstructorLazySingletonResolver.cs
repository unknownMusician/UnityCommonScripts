using System;
using System.Reflection;
using AreYouFruits.Common.DependencyInjection.Resolvers;
using AreYouFruits.Common.DependencyInjection.TypeResolvers;

namespace AreYouFruits.Common.DependencyInjection.Extensions.Binding.InjectedConstructorLazySingleton
{
    public sealed class InjectedConstructorLazySingletonResolver<TSource> : IResolver<TSource>
    {
        private readonly ConstructorInfo constructor;
        private object value;
        private bool isInitialized;

        public InjectedConstructorLazySingletonResolver()
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
            if (!isInitialized)
            {
                isInitialized = true;
                value = (TSource)Create(resolver);
            }

            return (TSource)value;
        }

        private object Create(IDiByTypeResolver resolver)
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

            return constructor.Invoke(parameters);
        }
    }
}
