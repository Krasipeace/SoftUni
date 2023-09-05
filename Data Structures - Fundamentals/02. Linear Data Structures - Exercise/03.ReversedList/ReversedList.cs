namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;
        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);

                return this.items[this.Count - index - 1];
            }
            set
            {
                ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public void Add(T item)
        {
            IncreaseSize();
            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
            => IndexOf(item) != -1;

        public int IndexOf(T item)
        {
            for (int i = 1; i <= this.Count; i++)
            {
                if (this.items[this.Count - i].Equals(item))
                {
                    return i - 1;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            IncreaseSize();
            ValidateIndex(index);
            int insertIndex = this.Count - index;

            for (int i = this.Count; i > insertIndex; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[insertIndex] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            int toRemove = this.Count - index - 1;
            for (int i = toRemove; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void Resize()
        {
            T[] values = new T[this.items.Length * 2];
            Array.Copy(this.items, values, this.items.Length);
            this.items = values;
        }

        private void IncreaseSize()
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}