using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> boxList;

        public Box()
        {
            boxList = new List<T>();
        }

        public void Add(T item)
        {
            boxList.Add(item);
        }

        public T Remove()
        {
            T removeItem = boxList[Count - 1];
            boxList.RemoveAt(Count - 1);

            return removeItem;
        }
        public int Count => boxList.Count;
    }
}
