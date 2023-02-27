namespace _6_Pancakes
{
    using System;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int[] numbers = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }

            int maxSum = int.MinValue;
            int currSum = 0;
            int currStartIndex = 0;
            int maxStartIndex = 0;
            int maxEndIndex = 0;
            int currEndIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                currSum += numbers[i];
                currEndIndex = i;

                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    maxStartIndex = currStartIndex;
                    maxEndIndex = currEndIndex;
                }
                else if (currSum == maxSum && currEndIndex - currStartIndex > maxEndIndex - maxStartIndex)
                {
                    maxStartIndex = currStartIndex;
                    maxEndIndex = currEndIndex;
                }

                if (currSum < 0)
                {
                    currSum = 0;
                    currStartIndex = i + 1;
                }
            }

            Console.WriteLine($"{maxSum} {maxStartIndex} {maxEndIndex}");
        }
    }
}