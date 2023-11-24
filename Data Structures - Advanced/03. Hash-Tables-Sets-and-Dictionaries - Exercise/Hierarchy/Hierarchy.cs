namespace Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Parent { get; set; }
            public List<Node> Children { get; set; }

            public Node(T value)
            {
                this.Value = value;
                this.Children = new List<Node>();
            }
        }

        private Node root;
        private Dictionary<T, Node> nodesByValue;

        public Hierarchy(T value)
        {
            this.root = new Node(value);
            this.nodesByValue = new Dictionary<T, Node>
            {
                { value, this.root }
            };
        }

        public int Count
            => this.nodesByValue.Count;

        public bool Contains(T element)
            => this.nodesByValue.ContainsKey(element);

        public void Add(T element, T child)
        {
            if (!nodesByValue.ContainsKey(element) || nodesByValue.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            var node = new Node(child)
            {
                Parent = nodesByValue[element]
            };

            nodesByValue.Add(child, node);
            nodesByValue[element].Children.Add(node);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            var commonElements = new List<T>();

            foreach (var element in this)
            {
                if (other.Contains(element))
                {
                    commonElements.Add(element);
                }
            }

            return commonElements;
        }

        public T GetParent(T element)
        {
            if (!this.nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            if (this.nodesByValue[element].Parent == null)
            {
                return default(T);
            }

            return this.nodesByValue[element].Parent.Value;
        }

        public IEnumerable<T> GetChildren(T element)
        {
            return !this.nodesByValue.ContainsKey(element)
                ? throw new ArgumentException()
                : this.nodesByValue[element].Children.Select(e => e.Value);
        }

        public void Remove(T element)
        {
            if (element.Equals(this.root.Value))
            {
                throw new InvalidOperationException();
            }

            if (!nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            var node = this.nodesByValue[element];
            var parentNode = node.Parent;

            parentNode.Children.Remove(node);
            parentNode.Children.AddRange(node.Children);

            foreach (var child in node.Children)
            {
                this.nodesByValue[child.Value].Parent = parentNode;
            }

            this.nodesByValue.Remove(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<Node>();
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                yield return currentNode.Value;

                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}