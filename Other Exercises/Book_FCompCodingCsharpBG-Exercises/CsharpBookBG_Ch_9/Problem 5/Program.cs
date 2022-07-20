using System;
using System.Linq;

namespace Problem_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array of integer numbers, splitted with interval: ");
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.Write("Enter index in the array: ");
            int userIndex = int.Parse(Console.ReadLine());

            CheckLeftAndRightIndex(userIndex, arr);
        }

        private static void CheckLeftAndRightIndex(int userIndex, int[] arr)
        {            
            if (userIndex == 0)
            {
                Console.WriteLine($"This is first number of the array and has no left index!");

                return;
            }

            if (userIndex == arr.Length - 1)
            {
                Console.WriteLine($"This is last number of the array and has no right index!");

                return;
            }

            if (userIndex > arr.Length - 1 || userIndex < 0)
            {
                Console.WriteLine($"This index does not exist in the array!");

                return;
            }

            if (arr[userIndex] < arr[userIndex - 1] && arr[userIndex] < arr[userIndex + 1])
            {
                Console.WriteLine($"The number in the index is smaller.");

                return;
            }
            else if (arr[userIndex] > arr[userIndex - 1] && arr[userIndex] > arr[userIndex + 1])
            {
                Console.WriteLine($"The number in the index is bigger.");

                return;
            }
            else
            {
                Console.WriteLine("Number is equal or both numbers are different.");

                return;
            }
        }
    }
}
