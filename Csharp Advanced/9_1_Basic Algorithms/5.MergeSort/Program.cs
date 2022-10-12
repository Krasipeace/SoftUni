using System;
using System.Linq;

namespace _5.MergeSort //https://en.wikipedia.org/wiki/Merge_sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            int[] sortedNumbers = MergeSort(numbers);

            Console.WriteLine(string.Join(" ", sortedNumbers));
        }

        static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers;
            }

            int[] leftPart = numbers.Take(numbers.Length / 2).ToArray();
            int[] rightPart = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MergeSort(leftPart), MergeSort(rightPart));
        }

        static int[] Merge(int[] leftPart, int[] rightPart)
        {
            int[] mergeParts = new int[leftPart.Length + rightPart.Length];

            int mergedIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < leftPart.Length && rightIndex < rightPart.Length)
            {
                if (leftPart[leftIndex] < rightPart[rightIndex])
                {
                    mergeParts[mergedIndex] = leftPart[leftIndex];
                    leftIndex++;
                }
                else
                {
                    mergeParts[mergedIndex] = rightPart[rightIndex];
                    rightIndex++;
                }
                mergedIndex++;
            }

            while (leftIndex < leftPart.Length)
            {
                mergeParts[mergedIndex] = leftPart[leftIndex];
                leftIndex++;
                mergedIndex++;
            }

            while (rightIndex < rightPart.Length)
            {
                mergeParts[mergedIndex] = rightPart[rightIndex];
                rightIndex++;
                mergedIndex++;
            }

            return mergeParts;
        }
    }
}