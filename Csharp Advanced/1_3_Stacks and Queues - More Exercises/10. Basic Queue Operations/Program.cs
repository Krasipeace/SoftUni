using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputCommands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int enqueueElements = inputCommands[0];
            int dequeueElements = inputCommands[1];
            int checkNumber = inputCommands[2];

            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < enqueueElements; i++)
            {
                numbers.Enqueue(inputNumbers[i]);
            }

            for (int i = 0; i < dequeueElements; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Contains(checkNumber))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
