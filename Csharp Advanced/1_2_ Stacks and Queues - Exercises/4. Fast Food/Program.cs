using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodAmount = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());
            while (queue.Count > 0)
            {
                if (queue.Peek() <= foodAmount)
                {
                    foodAmount -= queue.Peek();
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (queue.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
