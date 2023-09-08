namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree()
        {
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = this.FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        public void Delete(T element)
        {
            this.root = this.Delete(element, this.root);
        }

        private Node Delete(T element, Node node)
        {
            if (node == null)
            {
                throw new InvalidOperationException();
            }

            int compare = element.CompareTo(node.Value);

            if (compare < 0)
            {
                node.Left = this.Delete(element, node.Left);
            }
            else if (compare > 0)
            {
                node.Right = this.Delete(element, node.Right);
            }
            else
            {
                if (node.Right == null)
                {
                    return node.Left;
                }

                if (node.Left == null)
                {
                    return node.Right;
                }
            }

            return node;
        }

        public void DeleteMax()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            if (this.root.Right == null)
            {
                this.root = this.root.Left;
            }
            else
            {
                Node parent = this.root;
                Node current = this.root.Right;

                while (current.Right != null)
                {
                    parent = current;
                    current = current.Right;
                }

                parent.Right = current.Left;
            }
        }

        public void DeleteMin()
        {
            this.root = GetMinToDelete(this.root);
        }

        private Node GetMinToDelete(Node node)
        {
            if (node == null)
            {
                throw new InvalidOperationException();
            }

            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = GetMinToDelete(node.Left);

            return node;
        }

        public int Count()
        {
            if (this.root == null)
            {
                return 0;
            }

            int count = 0;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();
                count++;

                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
            }

            return count;
        }

        public int Rank(T element)
        {
            if (this.root == null)
            {
                return 0;
            }

            int count = 0;
            Stack<Node> stack = new Stack<Node>();
            Node currentNode = this.root;

            while (stack.Count != 0 || currentNode != null)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }

                currentNode = stack.Pop();

                if (currentNode.Value.CompareTo(element) < 0)
                {
                    count++;
                }

                currentNode = currentNode.Right;
            }

            return count;
        }

        public T Select(int rank)
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            Node current = this.root;

            while (current != null)
            {
                int count = this.Rank(current.Value);

                if (count == rank)
                {
                    return current.Value;
                }

                if (count < rank)
                {
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }

            throw new InvalidOperationException();
        }

        public T Ceiling(T element)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            Node result = null;
            Node current = root;

            while (current != null)
            {
                if (Comparer<T>.Default.Compare(current.Value, element) > 0)
                {
                    if (result == null || Comparer<T>.Default.Compare(current.Value, result.Value) < 0)
                    {
                        result = current;
                    }

                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return result == null
                ? throw new InvalidOperationException()
                : result.Value;
        }

        public T Floor(T element)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            Node current = root;
            T nearestSmallerValue = default;

            while (current != null)
            {
                if (current.Value.CompareTo(element) < 0)
                {
                    nearestSmallerValue = current.Value;
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }

            return nearestSmallerValue;
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {

            List<T> result = new List<T>();
            this.GetElements(this.root, startRange, endRange, result);

            return result;
        }

        private void GetElements(Node node, T start, T end, List<T> result)
        {
            if (node == null)
            {
                return;
            }

            int nodeInLowerRange = start.CompareTo(node.Value);
            int nodeInUpperRange = end.CompareTo(node.Value);

            if (nodeInLowerRange < 0)
            {
                this.GetElements(node.Left, start, end, result);
            }

            if (nodeInLowerRange <= 0 && nodeInUpperRange >= 0)
            {
                result.Add(node.Value);
            }

            if (nodeInUpperRange > 0)
            {
                this.GetElements(node.Right, start, end, result);
            }
        }

        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }
    }
}
