using System.Text;
using AreYouFruits.DependencyInjection.New;
using AreYouFruits.DependencyInjection.New.Generic;
using ResolverQuery;

var container = new GenericContainer();
            
container.Bind(new GenericBindRequest<ILogger>(() => new ConsoleLogger()));

var logger = container.Resolve(new GenericResolveRequest<ILogger>());

logger.Log("Finish.");

container.Bind(type: , filter: , resolver: );

FilterBuilder
    .

BindPathFilterBuilder
    .For(new PathType<InterfaceUserClass>("parameter"), new PathType<AnotherInterfaceUserClass>("anotherParameter"))
    .ForAny(5, 6)
    .For(new PathType<InterfaceUserModule>())
    .Build();

ResolverBuilder
    .ToOther<InterfaceImplementorClass>();
    .ToInjected<InterfaceInheritorClass>();
        .Singleton();
        .Transient();
    .ToFactory(() => new InterfaceInheritorClass());
        .Singleton();
        .Transient();

InitializationBuilder
    .WithInitialization(created => created.Initialize());
    .WithInjection(created => created.Inject);


container.Bind(new NewBindRequest(
        string,
        ,
        ResolverBuilder
            .ToFactory(() => new StringBuilder())
            .Singleton()
            .WithInitialization(s => ((StringBuilder)s).Append("[]").ToString())
            .Build()
    ));

namespace ResolverQuery
{
    public sealed class WithResolverBuilder
    {
        private readonly IResolver resolver;

        public WithResolverBuilder(IResolver resolver)
        {
            this.resolver = resolver;
        }

        public IResolver Build()
        {
            return resolver;
        }

        public WithResolverAndInitializerBuilder WithInitialization(Action<object> initializer)
        {
            return new WithResolverAndInitializerBuilder(resolver, new WithInitializationInitializer(initializer));
        }

        public WithResolverAndInitializerBuilder WithInjection(Func<object, Action> injectorProvider)
        {
            return new WithResolverAndInitializerBuilder(resolver, new WithInjectionInitializer(injectorProvider));
        }
    }
    
    public sealed class WithResolverAndInitializerBuilder
    {
        private readonly IResolver resolver;
        private readonly IInitializer initializer;

        public WithResolverAndInitializerBuilder(IResolver resolver, IInitializer initializer)
        {
            this.resolver = resolver;
            this.initializer = initializer;
        }

        public IResolver Build()
        {
            return new InitializingResolver(resolver, initializer);
        }
    }
    
    public sealed class ToInjected
    {
        public Type Type { get; }

        public ToInjected(Type type)
        {
            Type = type;
        }

        public WithResolverBuilder Singleton()
        {
            return new WithResolverBuilder(new ToInjectedResolver(new SingletonCreator(), Type));
        }

        public WithResolverBuilder Transient()
        {
            return new WithResolverBuilder(new ToInjectedResolver(new TransientCreator(), Type));
        }
    }
    
    public sealed class ToFactory
    {
        public Func<object> Factory { get; }

        public ToFactory(Func<object> factory)
        {
            Factory = factory;
        }

        public WithResolverBuilder Singleton()
        {
            return new WithResolverBuilder(new ToFactoryResolver(new SingletonCreator(), Factory));
        }

        public WithResolverBuilder Transient()
        {
            return new WithResolverBuilder(new ToFactoryResolver(new TransientCreator(), Factory));
        }
    }
    
    public static class ResolverBuilder
    {
        public static WithResolverBuilder ToOther(Type otherType)
        {
            return new WithResolverBuilder(new ToOtherResolver(otherType));
        }

        public static ToInjected ToInjected(Type type)
        {
            return new ToInjected(type);
        }

        public static ToFactory ToFactory(Func<object> factory)
        {
            return new ToFactory(factory);
        }
    }
}

public sealed class NewBindRequest
{
    public Type Type { get; }
    public IFilter Filter { get; }
    public IResolver Resolver { get; }

    public NewBindRequest(Type type, IFilter filter, IResolver resolver)
    {
        Type = type;
        Filter = filter;
        Resolver = resolver;
    }
}

public sealed class ResolvedContext
{
    // todo
}

public interface IFilter
{
    public bool Contains(ResolvedContext context);
}

public interface IInitializer
{
    public void Initialize(object value, Container container);
}

public sealed class WithInjectionInitializer : IInitializer
{
    private readonly Func<object, Action> injectorProvider;

    public WithInjectionInitializer(Func<object, Action> injectorProvider)
    {
        this.injectorProvider = injectorProvider;
    }

    public void Initialize(object value, Container container)
        // todo: get arguments from container
    {
        var injector = injectorProvider(value);
        injector.Invoke();
    }
}

public sealed class WithInitializationInitializer : IInitializer
{
    private Action<object> initializer;

    public WithInitializationInitializer(Action<object> initializer)
    {
        this.initializer = initializer;
    }

    public void Initialize(object value, Container container)
    {
        initializer(value);
    }
}

public sealed class InitializingResolver : IResolver
{
    private readonly IResolver resolver;
    private readonly IInitializer initializer;

    public InitializingResolver(IResolver resolver, IInitializer initializer)
    {
        this.resolver = resolver;
        this.initializer = initializer;
    }

    public object Resolve(Container container)
    {
        object resolved = resolver.Resolve(container);
        
        initializer.Initialize(resolved, container);

        return resolved;
    }
}

public interface IResolver
{
    public object Resolve(Container container);
}

public sealed class ToOtherResolver : IResolver
{
    public Type OtherType { get; }

    public ToOtherResolver(Type otherType)
    {
        OtherType = otherType;
    }

    public object Resolve(Container container)
    {
        return container.Resolve(new ResolveRequest(OtherType));
    }
}

public interface ICreator
{
    public object Get(Func<object> factory);
}

public sealed class TransientCreator : ICreator
{
    public object Get(Func<object> factory)
    {
        return factory();
    }
}

public sealed class SingletonCreator : ICreator
{
    private bool isInitialized;
    private object cache; 
    
    public object Get(Func<object> factory)
    {
        if (!isInitialized)
        {
            cache = factory();
            isInitialized = true;
        }
        
        return cache;
    }
}

public sealed class ToInjectedResolver : IResolver
{
    private readonly ICreator creator;
    private readonly Type type;

    public ToInjectedResolver(ICreator creator, Type type)
    {
        this.creator = creator;
        this.type = type;
    }

    public object Resolve(Container container)
    {
        // todo: optimize
        return creator.Get(() => Factory(type, container));
    }

    private static object Factory(Type type, Container container)
        // todo: get arguments from container
    {
        return Activator.CreateInstance(type)!;
    }
}

public sealed class ToFactoryResolver : IResolver
{
    private readonly ICreator creator;
    private readonly Func<object> factory;

    public ToFactoryResolver(ICreator creator, Func<object> factory)
    {
        this.creator = creator;
        this.factory = factory;
    }

    public object Resolve(Container container)
    {
        return creator.Get(factory);
    }
}

var initializer = new Initializer();

initializer.Register<Interface>()

public interface ILogger
{
    public void Log(string text);
}

public sealed class ConsoleLogger : ILogger
{
    public void Log(string text)
    {
        Console.WriteLine(text);
    }
}
