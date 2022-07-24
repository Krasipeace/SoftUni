using System;
using System.Collections.Generic;

namespace Problem_19 //task 21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] eachWord = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> newList = new List<string>();

            int maxLength = 0;

            for (int i = 0; i < eachWord.Length; i++)
            {
                maxLength = CheckOneLetterAtCenter(eachWord[i], maxLength);

                maxLength = CheckTwoLettersAtCenter(eachWord[i], maxLength);

                if (maxLength >= 3)
                {
                    newList.Add(eachWord[i]);
                }

            }
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }

        }

        private static int CheckOneLetterAtCenter(string input, int maxLength)
        {
            for (int i = 0; i < input.Length; i++)
            {
                {
                    maxLength = Math.Max(maxLength, FindPalindromeLength(i, i, input));
                }
            }

            return maxLength;
        }

        private static int CheckTwoLettersAtCenter(string input, int maxLength)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                maxLength = Math.Max(maxLength, FindPalindromeLength(i, i + 1, input));
            }

            return maxLength;
        }

        private static int FindPalindromeLength(int leftIndex, int rightIndex, string input)
        {
            while (leftIndex >= 0 && rightIndex < input.Length && input[leftIndex] == input[rightIndex])
            {
                leftIndex--;
                rightIndex++;
            }

            return rightIndex - leftIndex - 1;
        }
    }
}
