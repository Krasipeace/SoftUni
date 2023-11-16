namespace AA_Tree
{
    using System;
    using System.Xml.Linq;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node root;

        private class Node
        {
            public Node(T element)
            {
                this.Value = element;
                this.Level = 1;
            }

            public T Value { get; set; }
            public Node Right { get; set; }
            public Node Left { get; set; }
            public int Level { get; set; }
        }

        public int Count() => this.Count(this.root);

        private int Count(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + this.Count(root.Left) + this.Count(root.Right);
        }

        public void Insert(T element)
        {
            this.root = this.Insert(this.root, element);
        }

        private Node Insert(Node node, T element)
        {
            if (node == null)
            {
                return new Node(element);
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(node.Left, element);
            }
            else
            {
                node.Right = this.Insert(node.Right, element);
            }

            node = Skew(node);
            node = Split(node);

            return node;
        }

        private Node Skew(Node node)
        {
            if (node.Left != null && node.Level == node.Left.Level)
            {
                node = RotateLeft(node);
            }

            return node;
        }

        private Node RotateLeft(Node node)
        {
            Node tempNode = node.Left;
            node.Left = tempNode.Right;
            tempNode.Right = node;

            return tempNode;
        }

        private Node Split(Node node)
        {
            if (node.Right == null || node.Right.Right == null)
            {
                return node;
            }
            else if (node.Right.Right.Level == node.Level)
            {
                node = RotateRight(node);
                node.Level++;
            }

            return node;
        }

        private Node RotateRight(Node node)
        {
            Node tempNode = node.Right;
            node.Right = tempNode.Left;
            tempNode.Left = node;

            return tempNode;
        }

        public void Delete(T element)
        {
            this.root = this.Delete(this.root, element);
        }

        private Node Delete(Node node, T element)
        {
            if (node == null)
            {
                return null;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Delete(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Delete(node.Right, element);
            }
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                }
                else if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    Node temp = node.Right;

                    while (temp.Left != null)
                    {
                        temp = temp.Left;
                    }

                    node.Value = temp.Value;
                    node.Right = this.Delete(node.Right, temp.Value);
                }
            }

            if (node != null)
            {
                if (node.Left != null && node.Left.Level < node.Level - 1)
                {
                    node.Left.Level = node.Level - 1;
                }

                if (node.Right != null && node.Right.Level < node.Level - 1)
                {
                    node.Right.Level = node.Level - 1;
                }

                else if (node.Right != null && node.Right.Level == node.Level)
                {
                    node.Right.Level--;
                }
            }

            return node;
        }

        public bool Contains(T element)
        {
            Node currentNode = this.root;

            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(element) == 0)
                {
                    return true;
                }
                else if (currentNode.Value.CompareTo(element) > 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            return false;
        }

        public void InOrder(Action<T> action)
        {
            InOrderTraversal(this.root, action);
        }

        private void InOrderTraversal(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.Left, action);
            action(node.Value);
            InOrderTraversal(node.Right, action);
        }

        public void PreOrder(Action<T> action)
        {
            PreOrderTraversal(this.root, action);
        }

        private void PreOrderTraversal(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            action(node.Value);
            PreOrderTraversal(node.Left, action);
            PreOrderTraversal(node.Right, action);
        }

        public void PostOrder(Action<T> action)
        {
            PostOrderTraversal(this.root, action);
        }

        private void PostOrderTraversal(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            PostOrderTraversal(node.Left, action);
            PostOrderTraversal(node.Right, action);
            action(node.Value);
        }
    }
}