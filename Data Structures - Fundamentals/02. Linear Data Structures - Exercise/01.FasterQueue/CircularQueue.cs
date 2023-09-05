namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private int front;
        private int rear;
        private T[] queue;

        public CircularQueue()
        {        
            this.queue = new T[8];
        }

        public int Count { get; private set; }

        private int Capacity => this.queue.Length;

        public void Enqueue(T item)
        {
            CheckIfFull();

            this.queue[this.rear] = item;
            this.rear = (this.rear + 1) % Capacity;
            this.Count++;
        }

        public T Dequeue()
        {
            CheckIfEmpty();

            var element = this.queue[this.front];
            this.front = (this.front + 1) % Capacity;
            this.Count--;

            return element;
        }

        public T Peek()
        {
            CheckIfEmpty();

            return this.queue[this.front];
        }

        public T[] ToArray()
            => CopyQueue(new T[this.Count]);

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.queue[(this.front + i) % Capacity];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void CheckIfFull()
        {
            if (this.Count >= this.Capacity)
            {
                Resize();
            }
        }

        private void CheckIfEmpty()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException();
            }
        }

        private void Resize()
        {
            this.queue = CopyQueue(new T[2 * Capacity]);
            this.front = 0;
            this.rear = this.Count;
        }

        private T[] CopyQueue(T[] values)
        {
            var current = this.front;

            for (int i = 0; i < this.Count; i++)
            {
                values[i] = this.queue[current];
                current = (current + 1) % Capacity;
            }

            return values;
        }
    }
}
