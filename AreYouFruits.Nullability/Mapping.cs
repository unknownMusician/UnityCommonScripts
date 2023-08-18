using System;

namespace AreYouFruits.Nullability
{
    public partial struct Optional<T>
    {
        public readonly void Switch(Action<T> valueHandler)
        {
            if (isInitialized)
            {
                valueHandler(value);
            }
        }
        public readonly void Switch(Action emptyHandler)
        {
            if (!isInitialized)
            {
                emptyHandler();
            }
        }

        public readonly void Switch(Action emptyHandler, Action<T> valueHandler) => Switch(valueHandler, emptyHandler);
        public readonly void Switch(Action<T> valueHandler, Action emptyHandler)
        {
            if (isInitialized)
            {
                valueHandler(value);
            }
            else
            {
                emptyHandler();
            }
        }

        public readonly TResult Match<TResult>(Func<TResult> emptyHandler, Func<T, TResult> valueHandler)
        {
            return Match(valueHandler, emptyHandler);
        }
        
        public readonly TResult Match<TResult>(Func<T, TResult> valueHandler, Func<TResult> emptyHandler)
        {
            return isInitialized switch
            {
                true => valueHandler(value),
                false => emptyHandler(),
            };
        }
    }
}
