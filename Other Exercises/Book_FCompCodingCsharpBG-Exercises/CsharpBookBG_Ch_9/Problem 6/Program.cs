using System;
using System.Linq;

namespace Problem_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array of integer numbers, splitted with interval: ");
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine($"The first bigger element(index) from its neightbours in the array is: {GetTheFirstBiggerIndexOfTheElementFromArray(arr)}");
        }

        private static int GetTheFirstBiggerIndexOfTheElementFromArray(int[] array)
        {
            for (int currIndex = 1; currIndex < array.Length - 1; currIndex++)
            {
                if (array[currIndex] > array[currIndex - 1] && array[currIndex] > array[currIndex + 1])
                {
                    return currIndex;
                }
            }
            return -1;
        }
    }
}
