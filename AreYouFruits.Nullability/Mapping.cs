using System;

namespace AreYouFruits.Nullability
{
    public partial struct Optional<T>
    {
        public void Switch(Action<T> valueHandler, Action emptyHandler)
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

        public TResult Match<TResult>(Func<T, TResult> valueHandler, Func<TResult> emptyHandler)
        {
            return isInitialized switch
            {
                true => valueHandler(value),
                false => emptyHandler(),
            };
        }

    }
}
