using System;
using System.Linq;

namespace _6._Quick_Sort //not ideal solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            QuickSort(inputArray, 0, inputArray.Length - 1);

            foreach (var item in inputArray)
            {
                Console.Write($"{item} ");
            }
        }

        static int Partition(int[] inputArray, int left, int right)
        {
            int pivot = inputArray[left];
            while (true)
            {
                while (inputArray[left] < pivot)
                {
                    left++;
                }
                while (inputArray[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (inputArray[left] == inputArray[right])
                    {
                        return right;
                    }

                    int temp = inputArray[left];
                    inputArray[left] = inputArray[right];
                    inputArray[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        static void QuickSort(int[] inputArray, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(inputArray, left, right);

                if (pivot > 1)
                {
                    QuickSort(inputArray, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(inputArray, pivot + 1, right);
                }
            }
        }
    }
}

