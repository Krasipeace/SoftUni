namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public partial class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node head;
        private Node tail;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node node = new Node(item);
            if (this.head == null)
            {
                this.head = node; 
                this.tail = node;
            }
            else
            {
                this.head.Previous = node;
                node.Next = this.head;
                this.head = node;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node node = new Node(item);
            if (this.head == null)
            {
                this.head = node; 
                this.tail = node;
            }
            else
            {
                node.Previous = this.tail;
                this.tail.Next = node;
                this.tail = node;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            CheckIfEmpty();

            return this.head.Value;
        }

        public T GetLast()
        {
            CheckIfEmpty();

            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            CheckIfEmpty();

            Node node = this.head;

            if (this.head.Next == null)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                Node newNode = this.head.Next;
                newNode.Previous = null;
                this.head = newNode;
            }

            this.Count--;

            return node.Value;
        }

        public T RemoveLast()
        {
            CheckIfEmpty();

            Node node = this.tail;
            if (node.Previous == null)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                Node newNode = this.tail.Previous;
                newNode.Next = null;
                this.tail = newNode;
            }

            this.Count--;

            return node.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = this.head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void CheckIfEmpty()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}