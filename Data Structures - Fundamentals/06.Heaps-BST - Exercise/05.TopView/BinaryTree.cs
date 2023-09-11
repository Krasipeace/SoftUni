namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            var topView = new List<T>();
            var topNodes = new Dictionary<int, T>();
            var queue = new Queue<KeyValuePair<BinaryTree<T>, int>>();

            queue.Enqueue(new KeyValuePair<BinaryTree<T>, int>
                (this, 0));

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (!topNodes.ContainsKey(node.Value))
                {
                    topNodes.Add(node.Value, node.Key.Value);
                }

                if (node.Key.LeftChild != null)
                {
                    queue.Enqueue(new KeyValuePair<BinaryTree<T>, int>
                        (node.Key.LeftChild, node.Value - 1));
                }

                if (node.Key.RightChild != null)
                {
                    queue.Enqueue(new KeyValuePair<BinaryTree<T>, int>
                        (node.Key.RightChild, node.Value + 1));
                }
            }

            foreach (var node in topNodes.OrderBy(x => x.Key))
            {
                topView.Add(node.Value);
            }

            return topView;
        }
    }
}
