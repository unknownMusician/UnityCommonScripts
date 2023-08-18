using System;

namespace AreYouFruits.Nullability
{
    public partial struct Optional<T>
    {
        public T SetIfNull(T value)
        {
            if (!isInitialized)
            {
                this.value = value;
            }

            return this.value;
        }

        public Optional<T> SetIfNull(Optional<T> value)
        {
            if (!isInitialized)
            {
                this = value;
            }

            return this;
        }

        public Optional<T> SetIfNull(Func<Optional<T>> valueProvider)
        {
            if (!isInitialized)
            {
                this = valueProvider();
            }

            return this;
        }
        
        public T SetIfNull(Func<T> valueProvider)
        {
            if (!isInitialized)
            {
                value = valueProvider();
            }

            return value;
        }
    }
}
