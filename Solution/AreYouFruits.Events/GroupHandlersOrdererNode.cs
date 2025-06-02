using System;

namespace AreYouFruits.Events
{
    public sealed class GroupHandlersOrdererNode : IEquatable<GroupHandlersOrdererNode>
    {
        private readonly object value;
        
        private GroupHandlersOrdererNode(object value)
        {
            this.value = value;
        }

        public bool IsHandler(out Type handler)
        {
            if (value is Type storedHandler)
            {
                handler = storedHandler;
                return true;
            }

            handler = default;
            return false;
        }

        public bool IsGroup(out object group)
        {
            if (value is HandlersGroupIdentifier storedGroup)
            {
                group = storedGroup.HandlersGroup;
                return true;
            }

            group = default;
            return false;
        }

        public static GroupHandlersOrdererNode FromHandler(Type handler)
        {
            return new GroupHandlersOrdererNode(handler);
        }

        public static GroupHandlersOrdererNode FromGroup<TEvent>(HandlerGroupId<TEvent> group)
            where TEvent : IEvent
        {
            return new GroupHandlersOrdererNode(new HandlersGroupIdentifier(group.Group));
        }

        public bool Equals(GroupHandlersOrdererNode other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(value, other.value);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is GroupHandlersOrdererNode other && Equals(other);
        }

        public override int GetHashCode()
        {
            return value?.GetHashCode() ?? 0;
        }
    }
}