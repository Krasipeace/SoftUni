namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _first;
        private Node<T> _last;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>
            {
                Value = item,
                Next = this._first
            };

            this._first = newNode;
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>
            {
                Value = item,
                Next = null
            };

            this.Count++;

            if (this._first == null)
            {
                this._first = newNode;
                this._last = newNode;

                return;
            }

            this._last.Next = newNode;
            this._last = newNode;
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();

            return this._first.Value;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();

            var currentNode = this._first.Value;
            var currentNextNode = this._first.Next;

            while (currentNextNode != null)
            {
                currentNode = currentNextNode.Value;
                currentNextNode = currentNextNode.Next;
            }

            return currentNode;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();

            T removeFirst = this._first.Value;
            this._first = this._first.Next;
            this.Count--;

            return removeFirst;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();

            Count--;
            if (_first.Next == null)
            {
                T el = _first.Value;
                _first = null;
                return el;
            }

            var curr = _first;
            while (curr.Next.Next != null) curr = curr.Next;

            T element = curr.Next.Value;
            curr.Next = null;
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._first;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
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