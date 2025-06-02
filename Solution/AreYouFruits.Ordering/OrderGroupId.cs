namespace AreYouFruits.Ordering
{
    public readonly struct OrderGroupId<T>
    {
        private readonly GroupGraphOrderer<T> orderer;
        
        public object Group { get; }

        public OrderGroupId(GroupGraphOrderer<T> orderer, object group)
        {
            this.orderer = orderer;
            Group = group;
        }

        public OrderGroupId<T> AssignChild(T child)
        {
            orderer.AssignToGroupRaw(GroupGraphOrdererNode<T>.Value(child), Group);
            
            return this;
        }

        public OrderGroupId<T> AssignChild(OrderGroupId<T> childGroup)
        {
            orderer.AssignToGroupRaw(GroupGraphOrdererNode<T>.Group(childGroup), Group);
            
            return this;
        }

        public OrderGroupId<T> OrderBefore(T next)
        {
            orderer.OrderRaw(
                GroupGraphOrdererNode<T>.Group(this),
                GroupGraphOrdererNode<T>.Value(next)
            );
            
            return this;
        }

        public OrderGroupId<T> OrderBefore(OrderGroupId<T> nextGroup)
        {
            orderer.OrderRaw(
                GroupGraphOrdererNode<T>.Group(this),
                GroupGraphOrdererNode<T>.Group(nextGroup)
            );
            
            return this;
        }

        public OrderGroupId<T> OrderAfter(T previous)
        {
            orderer.OrderRaw(
                GroupGraphOrdererNode<T>.Value(previous),
                GroupGraphOrdererNode<T>.Group(this)
            );
            
            return this;
        }

        public OrderGroupId<T> OrderAfter(OrderGroupId<T> nextGroup)
        {
            orderer.OrderRaw(
                GroupGraphOrdererNode<T>.Group(nextGroup),
                GroupGraphOrdererNode<T>.Group(this)
            );
            
            return this;
        }
    }
}