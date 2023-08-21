namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _last;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> node = this._head;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            T removeHead = this._head.Value;
            this._head = this._head.Next;
            this.Count--;

            return removeHead;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>
            {
                Value = item,
                Next = null
            };
            this.Count++;

            if (this._head == null)
            {
                this._head = newNode;
                this._last = newNode;

                return;
            }

            this._last.Next = newNode;
            this._last = newNode;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this._head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = this._head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}