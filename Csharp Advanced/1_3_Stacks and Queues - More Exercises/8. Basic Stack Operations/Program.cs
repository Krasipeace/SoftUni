using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputCommands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int pushElements = inputCommands[0];
            int popElements = inputCommands[1];
            int checkNumber = inputCommands[2];

            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < pushElements; i++)
            {
                numbers.Push(inputNumbers[i]);
            }

            for (int i = 0; i < popElements; i++)
            {
                numbers.Pop();
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
