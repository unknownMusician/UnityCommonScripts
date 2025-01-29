namespace AreYouFruits.Ordering
{
    public readonly struct GroupGraphOrdererOrderGroupHelper<T>
    {
        private readonly GroupGraphOrderer<T> orderer;
        private readonly OrderGroupId<T> previousGroup;

        public GroupGraphOrdererOrderGroupHelper(GroupGraphOrderer<T> orderer, OrderGroupId<T> previousGroup)
        {
            this.orderer = orderer;
            this.previousGroup = previousGroup;
        }

        public void Before(T next)
        {
            orderer.OrderRaw(
                GroupGraphOrdererNode<T>.Group(previousGroup),
                GroupGraphOrdererNode<T>.Value(next)
            );
        }

        public void Before(OrderGroupId<T> nextGroup)
        {
            orderer.OrderRaw(
                GroupGraphOrdererNode<T>.Group(previousGroup),
                GroupGraphOrdererNode<T>.Group(nextGroup)
            );
        }
    }
}