namespace Tree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

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

            //var queue = new Queue<Tuple<Tree<int>, List<int>, int>>();
            //queue.Enqueue(new Tuple<Tree<int>, List<int>, int>(this, new List<int>() { this.Key }, this.Key));
            //BfsPathsEqualsGivenSum(queue, sum, result);

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

        private void BfsPathsEqualsGivenSum(Queue<Tuple<Tree<int>, List<int>, int>> queue, int sum, List<List<int>> result)
        {
            while (queue.Count > 0)
            {
                var currentTree = queue.Dequeue();

                foreach (var child in currentTree.Item1.Children)
                {
                    var newSum = currentTree.Item3 + child.Key;
                    var newPath = new List<int>(currentTree.Item2)
                    {
                        child.Key
                    };

                    if (newSum == sum)
                    {
                        result.Add(newPath);
                    }

                    queue.Enqueue(new Tuple<Tree<int>, List<int>, int>(child, newPath, newSum));
                }
            }
        }

        public List<Tree<int>> SubTreesWithGivenSum(int sum)
        {
            var result = new List<Tree<int>>();

            this.DfsCalculateSubtreesSum(this, result, sum);
            //this.BfsCalculateSubtreesSum(this, result, sum);

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

        private int BfsCalculateSubtreesSum(Tree<int> integerTree, List<Tree<int>> result, int sum)
        {
            var queue = new Queue<Tree<int>>();
            queue.Enqueue(integerTree);
            var sums = new List<int>();

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                var currentSum = currentNode.Key;

                foreach (var child in currentNode.Children)
                {
                    currentSum += child.Key;
                    queue.Enqueue(child);
                }

                sums.Add(currentSum);

                if (currentSum == sum)
                {
                    result.Add(currentNode);
                }
            }

            return sum;
        }
    }
}
