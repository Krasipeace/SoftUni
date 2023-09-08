namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;

            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T v1, T v2)
        {
             var lca = this.GetLca(this, v1, v2);

            return lca == null 
                ? throw new InvalidOperationException() 
                : lca.Value;
        }

        private BinaryTree<T> GetLca(BinaryTree<T> node, T v1, T v2)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.CompareTo(v1) == 0 || node.Value.CompareTo(v2) == 0)
            {
                return node;
            }

            var leftLca = this.GetLca(node.LeftChild, v1, v2);
            var rightLca = this.GetLca(node.RightChild, v1, v2);

            return leftLca != null && rightLca != null 
                ? node 
                : leftLca 
                ?? rightLca;
        }
    }
}
