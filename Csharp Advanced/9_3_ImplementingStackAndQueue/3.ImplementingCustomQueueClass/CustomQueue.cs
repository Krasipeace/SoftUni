using System;
using System.Collections.Generic;
using System.Text;

namespace _3.ImplementingCustomQueueClass
{
    public class CustomQueue
    {
        private const int INITIAL_CAPACITY = 4;
        private const int FIRST_ELEMENT_INDEX = 0;
        private int[] elements;
        private int count;

        public CustomQueue()
        {
            count = 0;
            elements = new int[INITIAL_CAPACITY];
        }
        public int Count => count;

        public void Enqueue(int element)
        {
            if (elements.Length == count)
            {
                IncreaseLength();
            }

            elements[count] = element;
            count++;
        }
        private void IncreaseLength()
        {
            int[] tempArray = new int[elements.Length * 2];
            elements.CopyTo(tempArray, 0);
            elements = tempArray;
        }

        public int Dequeue()
        {
            isValid();
                       
            int temp = elements[FIRST_ELEMENT_INDEX];
            elements[FIRST_ELEMENT_INDEX] = elements[FIRST_ELEMENT_INDEX + 1];
            count--;

            if (count == 0)
            {
                elements[elements.Length - 1] = 0;
            }

            return temp;
        }
        private void isValid()
        {
            if (count == 0)
            {
                throw new InvalidOperationException($"No elements in the Queue!");
            }
        }

        public int Peek()
        {
            return elements[FIRST_ELEMENT_INDEX];
        }

        public void Clear()
        {
            
        }

        public override string ToString()
        {
            return $"{string.Join(" ", elements)}";
        }

        
    }
}
