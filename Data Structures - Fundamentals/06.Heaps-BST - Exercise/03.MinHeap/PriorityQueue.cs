namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : MinHeap<T> where T : IComparable<T>
    {
        public PriorityQueue()
        {
            this.elements = new List<T>();
            this.priorities = new Dictionary<T, int>();
        }

        public void Enqueue(T element)
            => base.Add(element);
        
        public T Dequeue() => base.ExtractMin();

        public void DecreaseKey(T key)
            => base.HeapifyUp(this.priorities[key]);
    }
}
