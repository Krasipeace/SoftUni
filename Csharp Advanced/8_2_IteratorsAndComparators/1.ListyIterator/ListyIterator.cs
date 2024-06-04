using System.Collections.Generic;
using System.Linq;
using System;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private int index;
        public List<T> data;
        public ListyIterator(params T[] input)
        {
            this.data = new List<T>(input);
            this.index = 0;
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
    }
}
