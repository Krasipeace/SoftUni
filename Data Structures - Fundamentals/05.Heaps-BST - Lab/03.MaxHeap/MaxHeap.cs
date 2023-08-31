namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private readonly List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.Size - 1);
        }

        public T ExtractMax()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0];
            this.Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);
            this.HeapifyDown(0);

            return element;
        }

        public T Peek()
        {
            if (this.Size <= 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[0];
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = this.GetParentIndex(index);
            while (index > 0 && this.IsGreater(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) > 0;
        }

        private void Swap(int index, int parentIndex)
        {
            (this.elements[parentIndex], this.elements[index]) = (this.elements[index], this.elements[parentIndex]);
        }

        private void HeapifyDown(int index)
        {
            int leftChildIndex = this.GetLeftChildIndex(index);
            while (leftChildIndex < this.Size && this.IsGreater(leftChildIndex, index))
            {
                int toSwapWith = leftChildIndex;
                int rightChildIndex = this.GetRightChildIndex(index);
                if (rightChildIndex < this.Size && this.IsGreater(rightChildIndex, toSwapWith))
                {
                    toSwapWith = rightChildIndex;
                }

                this.Swap(toSwapWith, index);
                index = toSwapWith;
                leftChildIndex = this.GetLeftChildIndex(index);
            }
        }

        private int GetLeftChildIndex(int index)
        {
            return ((index * 2) + 1);
        }

        private int GetRightChildIndex(int index)
        {
            return ((index * 2) + 2);
        }
    }
}
