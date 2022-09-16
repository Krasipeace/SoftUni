using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_And_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] bottlesFilled = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(cupsCapacity);
            Stack<int> stack = new Stack<int>(bottlesFilled);

            int wastedLittersOfWater = 0;

            while (queue.Any() && stack.Any())
            {
                wastedLittersOfWater = CalculateWaterSpace(queue, stack, wastedLittersOfWater);
            }

            PrintResult(queue, stack, wastedLittersOfWater);
        }

        private static int CalculateWaterSpace(Queue<int> queue, Stack<int> stack, int wastedLittersOfWater)
        {
            int cup = queue.Dequeue();
            int bottle = stack.Pop();

            while (cup > 0)
            {
                cup -= bottle;
                if (cup <= 0)
                {
                    break;
                }
                if (stack.Any())
                {
                    bottle = stack.Pop();
                }
                else
                {
                    break;
                }
            }
            wastedLittersOfWater += Math.Abs(cup);
            return wastedLittersOfWater;
        }

        private static void PrintResult(Queue<int> queue, Stack<int> stack, int wastedLittersOfWater)
        {
            if (queue.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", queue)}");
            }
            else if (stack.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stack)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }
    }
}
