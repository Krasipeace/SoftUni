using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _2.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index;
        public List<T> data;
        public ListyIterator(params T[] input)
        {
            this.data = new List<T>(input);
            this.index = 0;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //public void Create(params T[] data)
        //{
        //    this.data = data.ToList();
        //}
        public bool Move()
        {
            if (this.index < this.data.Count - 1)
            {
                this.index++;

                return true;
            }

            return false;
        }
        public bool HasNext()
        {
            return this.index < this.data.Count - 1;
        }

        public void Print()
        {
            if (this.data.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.data[index]);
            }

        }
        public void PrintAll()
        {
            if (this.data.Count != 0)
                Console.WriteLine(String.Join(" ", this.data));
            else
                Console.WriteLine("Invalid Operation!");
        }        
    }
}
