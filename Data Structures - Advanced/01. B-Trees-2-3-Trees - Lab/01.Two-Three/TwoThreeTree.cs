namespace _01.Two_Three
{
    using System;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Insert(T element)
        {
            this.root = this.Insert(this.root, element);
        }

        private TreeNode<T> Insert(TreeNode<T> node, T element)
        {
            if (node == null)
            {
                return new TreeNode<T>(element);
            }

            if (node.IsLeaf())
            {
                return this.MergeNodes(node, new TreeNode<T>(element));
            }

            if (IsLesser(element, node.LeftKey))
            {
                var newNode = this.Insert(node.LeftChild, element);

                return newNode == node.LeftChild ? node : this.MergeNodes(node, newNode);
            }
            else if (node.IsTwoNode() || IsLesser(element, node.RightKey))
            {
                var newNode = this.Insert(node.MiddleChild, element);

                return newNode == node.MiddleChild ? node : this.MergeNodes(node, newNode);
            }
            else
            {
                var newNode = this.Insert(node.RightChild, element);

                return newNode == node.RightChild ? node : this.MergeNodes(node, newNode);
            }
        }

        private bool IsLesser(T element, T key) => element.CompareTo(key) < 0;

        private TreeNode<T> MergeNodes(TreeNode<T> currentNode, TreeNode<T> node)
        {
            if (currentNode.IsTwoNode())
            {
                if (IsLesser(currentNode.LeftKey, node.LeftKey))
                {
                    currentNode.RightKey = node.LeftKey;
                    currentNode.MiddleChild = node.LeftChild;
                    currentNode.RightChild = node.MiddleChild;
                }
                else
                {
                    currentNode.RightKey = currentNode.LeftKey;
                    currentNode.RightChild = currentNode.MiddleChild;
                    currentNode.MiddleChild = node.MiddleChild;
                    currentNode.LeftChild = node.LeftChild;
                    currentNode.LeftKey = node.LeftKey;
                }

                return currentNode;
            }
            else if (IsLesser(node.LeftKey, currentNode.LeftKey))
            {
                var newNode = new TreeNode<T>(currentNode.LeftKey)
                {
                    LeftChild = node,
                    MiddleChild = currentNode,
                };

                currentNode.LeftChild = currentNode.MiddleChild;
                currentNode.MiddleChild = currentNode.RightChild;
                currentNode.LeftKey = currentNode.RightKey;
                currentNode.RightKey = default;
                currentNode.RightChild = null;

                return newNode;
            }
            else if (IsLesser(node.LeftKey, currentNode.RightKey))
            {
                node.MiddleChild = new TreeNode<T>(currentNode.RightKey)
                {
                    LeftChild = node.MiddleChild,
                    MiddleChild = currentNode.RightChild,
                };

                node.LeftChild = currentNode;
                currentNode.RightKey = default;
                currentNode.RightChild = null;

                return node;
            }
            else
            {
                var newNode = new TreeNode<T>(currentNode.RightKey)
                {
                    LeftChild = currentNode,
                    MiddleChild = node,
                };

                node.LeftChild = currentNode.RightChild;
                currentNode.RightKey = default;
                currentNode.RightChild = null;

                return newNode;
            }
        }
        #region PrintTree
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }

        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
        #endregion
    }
}
