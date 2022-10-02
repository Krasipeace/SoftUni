using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data = new List<T>();
        public int Count => this.data.Count;

        public void Add(T item)
        {
            this.data.Add(item);
        }

        public T Remove()
        {
            var removedBox = this.data.Last();
            this.data.RemoveAt(this.data.Count - 1);

            return removedBox;
        }
    }
}
