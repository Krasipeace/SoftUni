using System;
using System.Linq;

namespace Problem_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer numbers with interval between them: ");
            string[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int currentNumber = int.Parse(arr[i]);
                sum += currentNumber;
            }

            Console.WriteLine($"Sum of all numbers is: {sum}");
        }
    }
}
