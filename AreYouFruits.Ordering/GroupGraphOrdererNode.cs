using System;

namespace AreYouFruits.Ordering
{
    public struct GroupGraphOrdererNode<T> : IEquatable<GroupGraphOrdererNode<T>>
    {
        private readonly object data;
        private readonly bool isGroup;
        
        private GroupGraphOrdererNode(object data, bool isGroup)
        {
            this.data = data;
            this.isGroup = isGroup;
        }

        public bool IsValue(out T value)
        {
            if (!isGroup && this.data is T storedValue)
            {
                value = storedValue;
                return true;
            }

            value = default;
            return false;
        }

        public bool IsGroup(out object group)
        {
            if (isGroup)
            {
                group = data;
                return true;
            }

            group = default;
            return false;
        }

        public static GroupGraphOrdererNode<T> Value(T value)
        {
            return new GroupGraphOrdererNode<T>(value, isGroup: false);
        }

        public static GroupGraphOrdererNode<T> Group(OrderGroupId<T> group)
        {
            return new GroupGraphOrdererNode<T>(group.Group, isGroup: true);
        }

        public bool Equals(GroupGraphOrdererNode<T> other)
        {
            return Equals(data, other.data);
        }

        public override bool Equals(object obj)
        {
            return obj is GroupGraphOrdererNode<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return data?.GetHashCode() ?? 0;
        }
    }
}