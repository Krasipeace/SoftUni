using System;
using System.Linq;

namespace Problem_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array of integer numbers, splitted with interval: ");
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.Write("Enter number that exist in the array: ");
            int number = int.Parse(Console.ReadLine());
            
            CheckNumber(number, arr);
        }

        private static void CheckNumber(int number, int[] arr)
        {
            int counter = 0;

            foreach (var item in arr)
            {
                if (item == number)
                {
                    counter++;
                }
            }

            PrintResult(number, counter);
        }

        private static void PrintResult(int number, int counter)
        {
            if (counter != 0)
            {
                Console.WriteLine($"The number {number} is found {counter} times in the array.");
            }
            else
            {
                Console.WriteLine($"The number {number} doesn't exist in the array!");
            }
        }
    }
}
