namespace AreYouFruits.Events
{
    internal readonly struct HandlersGroupIdentifier
    {
        public object HandlersGroup { get; }
    
        public HandlersGroupIdentifier(object handlersGroup)
        {
            HandlersGroup = handlersGroup;
        }
    }
}