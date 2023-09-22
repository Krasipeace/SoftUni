namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            var sb = new StringBuilder();

            this.DfsAsString(sb, this, 0);

            return sb.ToString().Trim();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent).Append(tree.Key).AppendLine();

            foreach (var child in tree.children)
            {
                this.DfsAsString(sb, child, indent + 2);
            }
        }

        public IEnumerable<T> GetMiddleKeys()
            => this.BfsResultKeys(tree => tree.children.Count > 0 && tree.Parent != null).Select(tree => tree.Key);

        public IEnumerable<T> GetLeafKeys()
            => this.BfsResultKeys(tree => tree.Children.Count == 0).Select(tree => tree.Key);

        private IEnumerable<Tree<T>> BfsResultKeys(Predicate<Tree<T>> predicate)
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (predicate.Invoke(current))
                {
                    result.Add(current);
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public T GetDeepestKey() => this.GetDeepestNode().Key;

        private Tree<T> GetDeepestNode()
        {
            var leaves = this.BfsResultKeys(tree => tree.Children.Count == 0);
            Tree<T> deepestNode = null;
            var maxDepth = 0;

            foreach (var leaf in leaves)
            {
                var depth = this.GetDepth(leaf);

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        private int GetDepth(Tree<T> leaf)
        {
            int depth = 0;
            var tree = leaf;
            while (tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;
            }

            return depth;
        }

        public IEnumerable<T> GetLongestPath()
        {
            var paths = new List<List<T>>();
            var currentPath = new List<T>();
            var deepestNode = this.GetDeepestNode();

            while (deepestNode != null)
            {
                currentPath.Add(deepestNode.Key);
                deepestNode = deepestNode.Parent;
            }

            currentPath.Reverse();
            paths.Add(currentPath);

            var longestPath = new List<T>();
            var maxLength = 0;

            foreach (var path in paths)
            {
                if (path.Count > maxLength)
                {
                    maxLength = path.Count;
                    longestPath = path;
                }
            }

            return longestPath;
        }
    }
}
