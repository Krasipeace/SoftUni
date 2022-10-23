using System;
using System.Collections.Generic;
using System.Text;

namespace _2.ImplementingCustomStackClass
{
    public class CustomStack
    {
        private const int INITIAL_CAPACITY = 4;
        private int[] elements;
        private int count;
        public CustomStack()
        {
            count = 0;
            elements = new int[INITIAL_CAPACITY];
        }
        public int Count { get { return count; } }

        public void Push(int element)
        {
            if (elements.Length == Count)
            {
                int[] nextElements = new int[elements.Length * 2];

                for (int i = 0; i < elements.Length; i++)
                {
                    nextElements[i] = elements[i];
                }
                elements = nextElements;
            }
            elements[count] = element;
            count++;
        }

        public int Pop()
        {

            if (elements.Length == 0)
            {
                throw new InvalidOperationException("The CustomStack is empty!");
            }

            int popped = elements[--count];

            elements[count] = default;

            return popped;
        }


        public void Peek()
        {
            if (elements.Length == 0)
            {
                throw new InvalidOperationException("The CustomStack is empty!");
            }

            Console.WriteLine(elements[count - 1]);
        }


        public override string ToString()
        {
            return $"{string.Join(" ", elements)}";
        }
    }

}

