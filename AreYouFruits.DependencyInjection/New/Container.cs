using System;
using System.Collections.Generic;
using AreYouFruits.Nullability;

namespace AreYouFruits.DependencyInjection.New
{
    public sealed class ParameterResolveContext
        // todo: Add parameter name
    {
        public Type RequestedType { get; }

        public ParameterResolveContext(Type requestedType)
        {
            RequestedType = requestedType;
        }
    }
    
    public interface IReadOnlyResolveContext
    {
        public IReadOnlyCollection<ParameterResolveContext> ParameterResolveContexts { get; }
    }
    
    public sealed class ResolveContext : IReadOnlyResolveContext
    {
        private readonly List<ParameterResolveContext> parameterResolveContexts = new();

        public ICollection<ParameterResolveContext> ParameterResolveContexts => parameterResolveContexts;

        IReadOnlyCollection<ParameterResolveContext> IReadOnlyResolveContext.ParameterResolveContexts
            => parameterResolveContexts;
    }

    public sealed class ContainerEntry
    {
        public Func<object> Resolver { get; }
        public Func<IReadOnlyResolveContext, bool> Filter { get; }

        public ContainerEntry(Func<object> resolver, Func<IReadOnlyResolveContext, bool> filter)
        {
            Resolver = resolver;
            Filter = filter;
        }
    }
    
    public sealed class Container
    {
        private readonly ResolveContext resolveContext = new();
        private readonly Dictionary<Type, ContainerEntry> bindings = new();

        public void Bind(BindRequest bindRequest)
        {
            if (bindRequest is null)
            {
                throw new ArgumentNullException(nameof(bindRequest));
            }

            if (!bindings.TryAdd(bindRequest.RequestedType, bindRequest.RequestedTypeProvider))
            {
                throw new InvalidOperationException(
                    $"Tried to bind the type {bindRequest.RequestedType.FullName}, that is already bound.");
            }
        }

        public object Resolve(ResolveRequest resolveRequest)
        {
            if (resolveRequest is null)
            {
                throw new ArgumentNullException(nameof(resolveRequest));
            }

            if (!bindings.TryGetValue(resolveRequest.RequestedType, out var requestedTypeProvider))
            {
                throw new KeyNotFoundException(
                    $"Tried to resolve the type {resolveRequest.RequestedType.FullName}, that is not bound.");
            }

            // todo: Make resolvers use separate container to gather the info about ResolveQueue.
            var parameterResolveContext = new ParameterResolveContext(resolveRequest.RequestedType);
            resolveContext.ParameterResolveContexts.Add(parameterResolveContext);
            
            object resolved = requestedTypeProvider();

            resolveContext.ParameterResolveContexts.Remove(parameterResolveContext);
            
            resolveContext.ParameterResolveContexts.Clear();

            var resolvedType = resolved?.GetType();
            
            if (resolvedType is null)
            {
                throw new ArgumentOutOfRangeException(
                    $"Tried to bind the type {resolveRequest.RequestedType.FullName} with a RequestedTypeProvider,"
                  + $"that returned Null");
            }
            
            if (!resolveRequest.RequestedType.IsInstanceOfType(resolved))
            {
                throw new ArgumentOutOfRangeException(
                    $"Tried to bind the type {resolveRequest.RequestedType.FullName} with a RequestedTypeProvider,"
                  + $"that returned the object of type {resolvedType}");
            }

            return resolved;
        }
    }
}
