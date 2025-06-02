using System;

namespace AreYouFruits.Nullability
{
    public partial struct Optional<T>
    {
        public T Set(Func<T> emptyProvider, Func<T, T> valueProvider) => Set(valueProvider, emptyProvider);
        public T Set(Func<T, T> valueProvider, Func<T> emptyProvider)
        {
            var value = isInitialized switch
            {
                true => valueProvider(this.value),
                false => emptyProvider(),
            };

            this = new Optional<T>(value);

            return value;
        }

        public Optional<T> Set(Func<Optional<T>> emptyProvider, Func<T, Optional<T>> valueProvider)
        {
            return Set(valueProvider, emptyProvider);
        }
        public Optional<T> Set(Func<T, Optional<T>> valueProvider, Func<Optional<T>> emptyProvider)
        {
            return this = isInitialized switch
            {
                true => valueProvider(value),
                false => emptyProvider(),
            };
        }
        
        public T SetIfNull(T value)
        {
            if (!isInitialized)
            {
                this = new Optional<T>(value);
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
                this = new Optional<T>(valueProvider());
            }

            return value;
        }
        
        public T SetIfInitialized(T value)
        {
            if (isInitialized)
            {
                this = new Optional<T>(value);
            }

            return this.value;
        }

        public Optional<T> SetIfInitialized(Optional<T> value)
        {
            if (isInitialized)
            {
                this = value;
            }

            return this;
        }

        public Optional<T> SetIfInitialized(Func<Optional<T>> valueProvider)
        {
            if (isInitialized)
            {
                this = valueProvider();
            }

            return this;
        }
        
        public T SetIfInitialized(Func<T> valueProvider)
        {
            if (isInitialized)
            {
                this = new Optional<T>(valueProvider());
            }

            return value;
        }

        public T SetOrThrow(T value)
        {
            if (isInitialized)
            {
                throw new InvalidOperationException("The Option is already initialized.");
            }
            
            this = new Optional<T>(value);

            return value;
        }

        public Optional<T> SetOrThrow(Optional<T> value)
        {
            if (isInitialized)
            {
                throw new InvalidOperationException("The Option is already initialized.");
            }
            
            this = value;

            return value;
        }
    }
}
