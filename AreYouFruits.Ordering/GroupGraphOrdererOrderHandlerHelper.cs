namespace AreYouFruits.Ordering
{
    public readonly struct GroupGraphOrdererOrderHandlerHelper<T>
    {
        private readonly GroupGraphOrderer<T> orderer;
        private readonly T value;

        public GroupGraphOrdererOrderHandlerHelper(GroupGraphOrderer<T> orderer, T value)
        {
            this.orderer = orderer;
            this.value = value;
        }

        public void Before(T next)
        {
            orderer.OrderRaw(
                GroupGraphOrdererNode<T>.Value(value),
                GroupGraphOrdererNode<T>.Value(next)
            );
        }

        public void Before(OrderGroupId<T> nextGroup)
        {
            orderer.OrderRaw(
                GroupGraphOrdererNode<T>.Value(value),
                GroupGraphOrdererNode<T>.Group(nextGroup)
            );
        }
    }
}