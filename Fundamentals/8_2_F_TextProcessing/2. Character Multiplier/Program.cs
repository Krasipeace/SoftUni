using System;
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

            for (int i = 0; i < minEqualLength; i++)
            {
                sum += inputOne[i] * inputTwo[i];
            }

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

            Console.WriteLine(sum);
        }
    }
}