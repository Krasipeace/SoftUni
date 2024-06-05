using System;
using System.Linq;

namespace _4.FoldAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine()
                                      .Split()
                                      .Select(int.Parse)
                                      .ToArray();

            int fold = inputArray.Length / 4;
            int[] sumArray = new int[2 * fold];

            for (int i = 0; i < fold; i++)
            {
                sumArray[i] = inputArray[fold - (i + 1)] + inputArray[fold + i];
                sumArray[sumArray.Length - 1 - i] = inputArray[sumArray.Length - 1 - i + fold] + 
                                                    inputArray[sumArray.Length - 1 - i + fold + (2 * i) + 1];
            }
            Console.WriteLine(string.Join(" ", sumArray));
        }
    }
}
