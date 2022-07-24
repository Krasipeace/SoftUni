using System;

namespace Problem_23 //task 25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter words (,): ");
            string[] words = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            Array.Sort(words);

            Console.WriteLine();
            Console.Write("Sorted words: ");
            foreach (var word in words)
            {
                Console.Write($"{word} ");
            }
        }
    }
}
