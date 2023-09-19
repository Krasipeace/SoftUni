namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            this.Value = element;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild
        {
            get; private set;
        }

        public string AsIndentedPreOrder(int indent)
        {
            var stringBuilder = new StringBuilder();
            this.PreOderDfs(stringBuilder, indent, this);

            return stringBuilder.ToString();
        }

        private void PreOderDfs(StringBuilder stringBuilder, int indent, IAbstractBinaryTree<T> binaryTree)
        {
            stringBuilder.AppendLine($"{new string(' ', indent)}{binaryTree.Value}");

            if (binaryTree.LeftChild != null)
            {
                this.PreOderDfs(stringBuilder, indent + 2, binaryTree.LeftChild);
            }

            if (binaryTree.RightChild != null)
            {
                this.PreOderDfs(stringBuilder, indent + 2, binaryTree.RightChild);
            }
        }

        public void ForEachInOrder(Action<T> action)
        {
            this.LeftChild?.ForEachInOrder(action);

            action.Invoke(this.Value);

            this.RightChild?.ForEachInOrder(action);
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.InOrder());
            }

            result.Add(this);

            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.InOrder());
            }

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.PostOrder());
            }

            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.PostOrder());
            }

            result.Add(this);

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>
            {
                this
            };

            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.PreOrder());
            }

            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.PreOrder());
            }

            return result;
        }
    }
}
