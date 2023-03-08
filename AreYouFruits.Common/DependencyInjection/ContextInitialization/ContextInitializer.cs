namespace AreYouFruits.DependencyInjection.ContextInitialization
{
    public static class ContextInitializer
    {
        private static readonly object Locker = new object();

        private static volatile bool isInitialized;

        public static void TryInitialize(IKeyedDiContainer container, ContextType contextType)
        {
            if (isInitialized)
            {
                return;
            }

            lock (Locker)
            {
                if (isInitialized)
                {
                    return;
                }

                MethodsWithInitializerAttributeCaller.Call(container, contextType);

                isInitialized = true;
            }
        }

        public static void Reset()
        {
            isInitialized = false;
        }
    }
}