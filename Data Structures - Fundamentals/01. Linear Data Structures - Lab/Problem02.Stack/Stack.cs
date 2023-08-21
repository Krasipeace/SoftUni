namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> current = this._top;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this._top.Value;
        }

        public T Pop()
        {
            this.EnsureNotEmpty();

            T topNodeItem = this._top.Value;
            Node<T> newTopNode = this._top.Next;

            this._top.Next = null;

            this._top = newTopNode;
            this.Count--;

            return topNodeItem;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>
            {
                Value = item,
                Next = this._top
            };

            this._top = newNode;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._top;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}