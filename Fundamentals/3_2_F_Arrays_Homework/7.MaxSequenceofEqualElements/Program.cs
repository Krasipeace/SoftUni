using System;
using System.Linq;

namespace _7.MaxSequenceofEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToArray();
            int length = 1;
            int start = 0;
            int bestLength = 0;
            int bestStart = 0;   

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    length++;
                    if (length > bestLength)
                    {
                        bestLength = length;
                        bestStart = start;
                    }
                }
                else 
                {
                    length = 1;
                    start = i;
                }
            }

            for (int j = bestStart; j < bestLength + bestStart; j++)
            {                  
                Console.Write($"{array[j]} ");
            }
        }
    }
}

