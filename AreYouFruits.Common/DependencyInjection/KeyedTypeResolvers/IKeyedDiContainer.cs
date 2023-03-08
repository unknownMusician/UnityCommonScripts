namespace AreYouFruits.DependencyInjection
{
    public interface IKeyedDiContainer : IDiContainer
    {
        public IDiContainer For(object key);
    }
}