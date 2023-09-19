namespace Demo
{
    using System;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new string[]
            {
                "9 17", "9 4", "9 14", "4 36", "14 53", "14 59", "53 67", "53 73"
            };

            var factory = new TreeFactory();
            var treeFactory = factory.CreateTreeFromStrings(tree);

            //Console.WriteLine(treeFactory.GetAsString());

            Console.WriteLine(string.Join(" ", treeFactory.GetLeafKeys()));
        }
    }
}
