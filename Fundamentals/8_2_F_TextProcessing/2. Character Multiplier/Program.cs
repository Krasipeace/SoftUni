﻿using System;
using System.Text;

namespace _2._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            StringBuilder inputOne = new StringBuilder(input[0]);
            StringBuilder inputTwo = new StringBuilder(input[1]);

            int minEqualLength = (Math.Max(inputOne.Length, inputTwo.Length) - Math.Abs(inputOne.Length - inputTwo.Length));
            int sum = 0;

            sum = ClaculateEqualLength(inputOne, inputTwo, minEqualLength, sum);

            sum = ClaculateRemainingCharacters(inputOne, inputTwo, minEqualLength, sum);

            Console.WriteLine(sum);
        }

        private static int ClaculateEqualLength(StringBuilder inputOne, StringBuilder inputTwo, int minEqualLength, int sum)
        {
            for (int i = 0; i < minEqualLength; i++)
            {
                sum += inputOne[i] * inputTwo[i];
            }

            return sum;
        }

        private static int ClaculateRemainingCharacters(StringBuilder inputOne, StringBuilder inputTwo, int minEqualLength, int sum)
        {
            if (inputOne.Length > inputTwo.Length)
            {
                for (int i = minEqualLength; i < inputOne.Length; i++)
                {
                    sum += inputOne[i];
                }
            }
            else if (inputTwo.Length > inputOne.Length)
            {
                for (int i = minEqualLength; i < inputTwo.Length; i++)
                {
                    sum += inputTwo[i];
                }
            }

            return sum;
        }
    }
}