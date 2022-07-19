using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4
{
    internal class Program
    {
        //{2, 1, 1, 2, 3, 3, 2, 2, 2, 1} >>>>> {2, 2, 2}.
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int firstCounter = 0;
            int secondCounter = 0;
            int sequence = numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    firstCounter++;

                    if (firstCounter > secondCounter)
                    {
                        secondCounter = firstCounter;
                        sequence = numbers[i];
                    }
                }
                else
                {
                    firstCounter = 0;
                }
            }

            for (int i = 0; i <= secondCounter; i++)
            {
                Console.Write(sequence + " ");
            }
        }
    }
}
