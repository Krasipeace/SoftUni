namespace Demo
{
    using System;
    using System.Linq;

    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            var input = new string[]
            {
                "7 19", 
                "7 21", 
                "7 14", 
                "19 1", 
                "19 12", 
                "19 31", 
                "14 23", 
                "14 6",
            };

            var treeFactory = new TreeFactory();

            var tree = treeFactory.CreateTreeFromStrings(input);

            Console.WriteLine("Tree As String:");
            Console.WriteLine(tree.GetAsString());
            Console.WriteLine();

            Console.WriteLine($"Leaf Keys: {string.Join(", ", tree.GetLeafKeys())}");
            Console.WriteLine();

            Console.WriteLine($"Deepest Key: {string.Join(", ", tree.GetDeepestKey())}");
            Console.WriteLine();

            Console.WriteLine($"Longest Path to Root(left-most): {string.Join(" ", tree.GetLongestPath())}"); 

            tree.PathsWithGivenSum(27); // dubug -> 7,19,1 -> 7,14,6
            tree.GetSubtreesWithGivenSum(43); // debug -> 14 23 6
        }
    }
}
