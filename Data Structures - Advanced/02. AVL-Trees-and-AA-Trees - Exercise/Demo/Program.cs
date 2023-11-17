using System;

using AVLTree;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var tree = new AVL<int>();

            tree.Insert(41);
            tree.Insert(20);
            tree.Insert(65);
            tree.Insert(11);
            tree.Insert(50);
            tree.Insert(29);
            tree.Insert(91);
            tree.Insert(32);
            tree.Insert(72);
            tree.Insert(99);

            Console.WriteLine(tree.Root);
            Console.WriteLine(tree.Root.Left);
            Console.WriteLine(tree.Root.Right);
            Console.WriteLine();
            tree.Delete(50);
            Console.WriteLine();
            Console.WriteLine(tree.Root);
            Console.WriteLine(tree.Root.Left);
            Console.WriteLine(tree.Root.Right);
        }
    }
}
