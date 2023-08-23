namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;
        private readonly T value;
        private Tree<T> parent;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> parentNode = this.BfsNode(parentKey) ?? throw new ArgumentNullException();

            parentNode.children.Add(child);
            child.parent = parentNode;
        }

        public IEnumerable<T> OrderBfs()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<T> result = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();
                result.Add(subtree.value);

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            List<T> list = new List<T>();
            this.Dfs(this, list);

            return list;
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> toBeDeletedNode = BfsNode(nodeKey) ?? throw new ArgumentNullException();
            Tree<T> parentNode = toBeDeletedNode.parent ?? throw new ArgumentException();
            parentNode.children.Remove(toBeDeletedNode);
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = this.BfsNode(firstKey);
            Tree<T> secondNode = this.BfsNode(secondKey);
            if (firstNode is null || secondNode is null)
            {
                throw new ArgumentNullException();
            }

            Tree<T> firstParent = firstNode.parent;
            Tree<T> secondParent = secondNode.parent;
            if (firstParent is null || secondParent is null)
            {
                throw new ArgumentException();
            }

            int firstChildPos = firstParent.children.IndexOf(firstNode);
            int secondChildPos = secondParent.children.IndexOf(secondNode);

            firstParent.children[firstChildPos] = secondNode;
            secondNode.parent = firstParent;

            secondParent.children[secondChildPos] = firstNode;
            firstNode.parent = secondParent;
        }

        private Tree<T> BfsNode(T parentKey)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();

                if (subtree.value.Equals(parentKey))
                {
                    return subtree;
                }

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private void Dfs(Tree<T> node, ICollection<T> result)
        {
            foreach (var child in node.children)
            {
                this.Dfs(child, result);
            }

            result.Add(node.value);
        }
    }
}