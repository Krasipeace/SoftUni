using System;

namespace _1._Longest_Palindrome_Sub_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int maxLength = 0;

            maxLength = CheckOneLetterAtCenter(input, maxLength);

            maxLength = CheckTwoLettersAtCenter(input, maxLength);

            Console.WriteLine(maxLength);
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
