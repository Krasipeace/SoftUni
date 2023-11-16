using System;
using System.Xml;
using System.Xml.Linq;

using AA_Tree;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            AATree<int> tree = new AATree<int>();
            tree.Insert(6);
            tree.Insert(2);
            tree.Insert(8);
            tree.Insert(16);
            tree.Insert(10);
            Console.WriteLine(tree.Contains(16)); // True
            Console.WriteLine(tree.Contains(4)); // False
            Console.WriteLine(tree.Count()); // 5
            tree.InOrder(node => Console.Write($"{node} ")); // 2 6 8 10 16
            Console.WriteLine();
            tree.PreOrder(node => Console.Write($"{node} ")); // 6 2 10 8 16
            Console.WriteLine();
            tree.PostOrder(node => Console.Write($"{node} ")); // 2 8 16 10 6
            Console.WriteLine();
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(25);
            tree.InOrder(node => Console.Write($"{node} ")); // 2 6 8 10 16 20 25 30
            tree.Delete(10);
            Console.WriteLine();
            tree.InOrder(node => Console.Write($"{node} ")); // 2 6 8 16 20 25 30
        }
    }
}
