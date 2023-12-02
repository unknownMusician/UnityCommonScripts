namespace AreYouFruits.DependencyInjection.New.Generic
{
    public sealed class GenericResolveRequest<T>
    {
        public ResolveRequest ToResolveRequest()
        {
            return new ResolveRequest(typeof(T));
        }
    }
}
