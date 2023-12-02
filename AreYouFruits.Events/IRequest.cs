namespace AreYouFruits.EventBus
{
    public interface IRequest<TResponse>
        where TResponse : IResponse { }
}
