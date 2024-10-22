using System.Collections;
using System.Collections.Generic;

namespace AreYouFruits.Events
{
    public sealed class SubstitutingTakenWithLastList<T> : IList<T>, IReadOnlyList<T>
    {
        private readonly List<T> list;

        public int Count => list.Count;
        public bool IsReadOnly => ((ICollection<T>)list).IsReadOnly;
        
        public T this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }

        private SubstitutingTakenWithLastList(List<T> list)
        {
            this.list = list;
        }
        
        public SubstitutingTakenWithLastList() : this(new List<T>()) { }
        public SubstitutingTakenWithLastList(IEnumerable<T> collection) : this(new List<T>(collection)) { }
        public SubstitutingTakenWithLastList(int capacity) : this(new List<T>(capacity)) { }

        public List<T>.Enumerator GetEnumerator() => list.GetEnumerator();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void Add(T item) => list.Add(item);
        public void Clear() => list.Clear();
        public bool Contains(T item) => list.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);
        public bool Remove(T item) => list.Remove(item);
        public int IndexOf(T item) => list.IndexOf(item);
        public void Insert(int index, T item) => list.Insert(index, item);
        public void RemoveAt(int index)
        {
            if ((index < 0) || (index >= list.Count) || (list.Count == 1))
            {
                list.RemoveAt(index);
                return;
            }

            var last = list[^1];
            list.RemoveAt(list.Count - 1);

            list[index] = last;
        }
    }
}
