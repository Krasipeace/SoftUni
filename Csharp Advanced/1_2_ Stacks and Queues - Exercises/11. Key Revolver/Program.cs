using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int cash = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(bullets);
            Queue<int> queue = new Queue<int>(locks);

            int counter = 0;
            while (stack.Any() && queue.Any())
            {
                int bulletSize = stack.Pop();
                int lockSize = queue.Peek();
                counter++;

                if (bulletSize <= lockSize)
                {
                    queue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (counter % gunBarrel == 0 && stack.Any())
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (queue.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queue.Count()}");
            }
            else
            {
                Console.WriteLine($"{stack.Count()} bullets left. Earned ${Math.Abs(cash - (counter * bulletPrice))}");
            }
        }
    }
}
