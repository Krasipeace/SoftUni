using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            for (int i = 1; i <= 10; i++)
            {
                doublyLinkedList.AddFirst(i);
            }

            int[] arr = doublyLinkedList.ToArray();

            doublyLinkedList.ForEach(n => Console.Write($"{n} "));

            Console.WriteLine("\nAdded 17 at first Index: ");
            doublyLinkedList.AddFirst(17);
            doublyLinkedList.ForEach(n => Console.Write($"{n} "));

            Console.WriteLine("\nAdded 69 at last Index: ");
            doublyLinkedList.AddLast(69);
            doublyLinkedList.ForEach(n => Console.Write($"{n} "));

            Console.Write("\nFirst Removed Element is :");
            Console.WriteLine(doublyLinkedList.RemoveFirst());
            doublyLinkedList.ForEach(n => Console.Write($"{n} "));

            Console.Write("\nLast Removed Element is :");
            Console.WriteLine(doublyLinkedList.RemoveLast());

            Console.WriteLine("----******************-----");
            doublyLinkedList.ForEach(n => Console.Write($"{n} "));
        }
    }
}

