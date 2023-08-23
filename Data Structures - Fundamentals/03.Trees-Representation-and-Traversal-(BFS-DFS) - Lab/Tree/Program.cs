namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Tree<int> newTree = 
                new Tree<int>(7,
                    new Tree<int>(19,
                        new Tree<int>(1),
                        new Tree<int>(12),
                        new Tree<int>(31)),
                    new Tree<int>(21),
                    new Tree<int>(14,
                        new Tree<int>(23),
                        new Tree<int>(6))
            );

            newTree.AddChild(7, new Tree<int>(8));
            newTree.OrderBfs();
            newTree.OrderDfs();
            newTree.Swap(19, 14);
            newTree.RemoveNode(21);
        }
    }
}
