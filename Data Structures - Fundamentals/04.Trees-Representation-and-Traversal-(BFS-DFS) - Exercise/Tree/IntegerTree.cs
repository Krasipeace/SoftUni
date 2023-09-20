namespace Tree
{
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

        public List<Tree<int>> SubTreesWithGivenSum(int sum)
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
    }
}
