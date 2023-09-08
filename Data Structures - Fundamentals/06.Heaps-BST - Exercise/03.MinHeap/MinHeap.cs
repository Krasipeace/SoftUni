namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        protected Dictionary<T, int> priorities;

        public MinHeap()
        {
            this.elements = new List<T>();
            this.priorities = new Dictionary<T, int>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.priorities.Add(element, this.Size - 1);
            this.HeapifyUp(this.Size - 1);
        }

        public T ExtractMin()
        {
            SizeValidation();

            T element = this.elements[0];
            this.Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);
            this.HeapifyDown(0);

            return element;
        }

        public T Peek()
        {
            SizeValidation();

            return this.elements[0];
        }

        protected void HeapifyUp(int index)
        {
            int parent = this.GetParent(index);

            while (index > 0 && IsSmaller(index, parent))
            {
                this.Swap(index, parent);
                index = parent;
                parent = this.GetParent(index);
            }
        }

        protected void HeapifyDown(int index)
        {
            int smaller = this.GetSmallerChild(index);

            while (this.IsValid(smaller) && IsGreater(index, smaller))
            {
                this.Swap(index, smaller);
                index = smaller;
                smaller = this.GetSmallerChild(index);
            }
        }

        private int GetSmallerChild(int index)
        {
            int leftChild = this.GetLeftChild(index);
            int rightChild = this.GetRightChild(index);

            if (IsValid(rightChild))
            {
                if (IsSmaller(leftChild, rightChild))
                {
                    return leftChild;
                }

                return rightChild;
            }
            else if (IsValid(leftChild))
            {
                return leftChild;
            }
            else
            {
                return index;
            }
        }

        private void SizeValidation()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private int GetParent(int index)
            => (index - 1) / 2;

        private bool IsGreater(int index, int parent)
            => this.elements[index].CompareTo(this.elements[parent]) > 0;

        private bool IsSmaller(int leftChild, int rightChild)
            => this.elements[leftChild].CompareTo(this.elements[rightChild]) < 0;

        private void Swap(int index, int parent)
            => (this.elements[parent], this.elements[index]) = (this.elements[index], this.elements[parent]);

        private int GetLeftChild(int index)
            => (index * 2) + 1;

        private int GetRightChild(int index)
            => (index * 2) + 2;

        private bool IsValid(int index)
            => index >= 0 && index < this.elements.Count;
    }
}
