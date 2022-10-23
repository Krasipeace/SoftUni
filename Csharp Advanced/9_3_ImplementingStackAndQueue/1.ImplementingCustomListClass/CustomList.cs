using System;
using System.Collections.Generic;
using System.Text;

namespace CustomListClass
{
    public class CustomList
    {
        private const int INITIAL_CAPACITY = 2;
        private int[] items;
        public CustomList()
        {
            this.items = new int[INITIAL_CAPACITY];
        }
        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException($"Index is out of range!");
                }
                return items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException($"Index is out of range!");
                }
                items[index] = value;
            }
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Count] = item;
            this.Count++;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        public int RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException($"Index is out of range/invalid!");
            }

            int item = this.items[index];
            this.items[index] = default(int);
            this.Shift(index);
            this.Count--;

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return item;
        }

        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        public void Insert(int index, int element)
        {
            if (index > this.Count)
            {
                throw new IndexOutOfRangeException($"Index is out of range/invalid!");
            }
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            ShiftToRight(index);
            this.items[index] = element;
            this.Count++;
        }

        //public bool Equals(int element, int elementTwo)
        //{
        //    if (element == elementTwo)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                int item = this.items[i];

                if (item.Equals(element))
                {
                    Console.WriteLine($"True"); 
                    
                    return true;
                }
            }
            Console.WriteLine($"False");

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            int swappedIndex = this.items[firstIndex];
            if (firstIndex >= 0 && firstIndex < this.Count && secondIndex >= 0 && secondIndex < this.Count)
            {
                this.items[firstIndex] = this.items[secondIndex];
                this.items[secondIndex] = swappedIndex;
            }
            else
            {
                throw new InvalidOperationException($"One or both index(es) are invalid!");
            }
            
        }

        public override string ToString()
        {
            return $"{string.Join(" ", items)}";
        }
    }
}
