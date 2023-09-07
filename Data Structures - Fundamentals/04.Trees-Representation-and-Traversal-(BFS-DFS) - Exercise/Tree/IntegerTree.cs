namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public List<List<int>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<int>>();

            var currentPath = new LinkedList<int>();
            currentPath.AddFirst(this.Key);

            int currentSum = this.Key;
            this.DfsPathsEqualsGivenSum(this, result, currentPath, ref currentSum, sum);

            return result;
        }

        private void DfsPathsEqualsGivenSum(Tree<int> integerTree, List<List<int>> result, LinkedList<int> currentPath, ref int currentSum, int sum)
        {
            foreach (var child in integerTree.Children)
            {
                currentSum += child.Key;
                currentPath.AddLast(child.Key);
                this.DfsPathsEqualsGivenSum(child, result, currentPath, ref currentSum, sum);
            }

            if (currentSum == sum)
            {
                result.Add(new List<int>(currentPath));
            }

            currentSum -= integerTree.Key;
            currentPath.RemoveLast();
        }
        public List<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            var result = new List<Tree<int>>();

            this.DfsCalculateSubtreesSum(this, result, sum);

            return result;
        }

        private int DfsCalculateSubtreesSum(Tree<int> integerTree, List<Tree<int>> result, int sum)
        {
            int currentSum = integerTree.Key;

            foreach (var child in integerTree.Children)
            {
                currentSum += this.DfsCalculateSubtreesSum(child, result, sum);
            }

            if (currentSum == sum)
            {
                result.Add(integerTree);
            }

            return currentSum;
        }

        public new List<int> GetLeafKeys()
        {
            var result = new List<Tree<int>>();
            var queue = new Queue<Tree<int>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Children.Count == 0)
                {
                    result.Add(current);
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result.Select(tree => tree.Key).ToList();
        }

        public new List<int> GetMiddleKeys()
        {
            var result = new List<Tree<int>>();
            var queue = new Queue<Tree<int>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Children.Count == 0 && current.Parent != null)
                {
                    result.Add(current);
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result.Select(tree => tree.Key).ToList();
        }
    }
}
