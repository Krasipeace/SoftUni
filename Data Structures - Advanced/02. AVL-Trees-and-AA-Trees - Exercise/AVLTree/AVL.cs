namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Height = 1;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }

            public override string ToString()
            {
                return $"Value: {this.Value} Height: {this.Height}";
            }
        }

        public Node Root { get; private set; }

        public bool Contains(T element)
        {
            return this.Contains(this.Root, element) != null;
        }

        private Node Contains(Node node, T element)
        {
            while (node != null)
            {
                int compareNode = element.CompareTo(node.Value);
                if (compareNode < 0)
                {
                    node = node.Left;
                }
                else if (compareNode > 0)
                {
                    node = node.Right;
                }
                else
                {
                    return node;
                }
            }

            return null;
        }

        public void Delete(T element)
        {
            this.Root = this.Delete(this.Root, element);
        }

        private Node Delete(Node node, T element)
        {
            if (node == null)
            {
                return null;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Delete(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = Delete(node.Right, element);
            }
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    return null;
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
                    Node minNode = this.FindMin(node.Right);
                    node.Value = minNode.Value;
                    node.Right = this.Delete(node.Right, minNode.Value);
                }
            }

            node = this.BalanceTree(node);
            node.Height = this.UpdateNodeHeight(node);

            return node;
        }

        private Node FindMin(Node rightNode)
        {
            if (rightNode.Left == null)
            {
                return rightNode;
            }

            return this.FindMin(rightNode.Left);
        }

        public void DeleteMin()
        {
            if (this.Root == null)
            {
                return;
            }

            var deleteMin = this.FindMin(this.Root);
            this.Root = this.Delete(this.Root, deleteMin.Value);
        }

        public void Insert(T element)
        {
            this.Root = Insert(this.Root, element);
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

            node = BalanceTree(node);
            node.Height = UpdateNodeHeight(node);

            return node;
        }

        private Node BalanceTree(Node node)
        {
            int balanceFactor = GetHeight(node.Left) - GetHeight(node.Right);

            if (balanceFactor > 1)
            {
                var childBalanceFactor = GetHeight(node.Left.Left) - GetHeight(node.Left.Right);
                if (childBalanceFactor < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                node = RotateRight(node);
            }
            else if (balanceFactor < -1)
            {
                var childBalanceFactor = GetHeight(node.Right.Left) - GetHeight(node.Right.Right);
                if (childBalanceFactor > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                node = RotateLeft(node);
            }

            return node;
        }

        private int UpdateNodeHeight(Node node)
        {
            return Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }

        private int GetHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private Node RotateLeft(Node node)
        {
            Node right = node.Right;
            node.Right = right.Right.Left;
            right.Left = node;

            node.Height = UpdateNodeHeight(node);

            return right;
        }

        private Node RotateRight(Node node)
        {
            Node left = node.Left;
            node.Left = left.Left.Right;
            left.Right = node;

            node.Height = UpdateNodeHeight(node);

            return left;
        }

        public void EachInOrder(Action<T> action)
        {
            InOrderTraversal(this.Root, action);
        }

        private void InOrderTraversal(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.InOrderTraversal(node.Left, action);
            action(node.Value);
            this.InOrderTraversal(node.Right, action);
        }
    }
}
