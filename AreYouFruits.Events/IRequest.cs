namespace AreYouFruits.Events
{
    public interface IRequest<TResponse>
        where TResponse : IResponse { }
}
