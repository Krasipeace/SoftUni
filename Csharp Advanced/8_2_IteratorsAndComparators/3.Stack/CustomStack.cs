using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _3.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> data;
        public int Count => data.Count;
        public CustomStack()
        {
            this.data = new List<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = data.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Push(params T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.data.Add(elements[i]);
            }
        }
        public void Pop()
        {
            this.data.RemoveAt(data.Count - 1);
        }
    }
}
