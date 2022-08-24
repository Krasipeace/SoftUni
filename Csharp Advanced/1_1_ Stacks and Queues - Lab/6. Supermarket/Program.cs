using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                if (input != "Paid")
                {
                    queue.Enqueue(input);
                }
                else if (input == "Paid")
                {
                    while (queue.Any())
                    {
                        Console.WriteLine($"{queue.Dequeue()}");
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
