using System;

namespace FromLeftToRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                long greaterLeft = 0;
                long greaterRight = 0;

                string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string left = numbers[0];
                string right = numbers[1];

                long numberLeft = long.Parse(left);
                long numberRight = long.Parse(right);

                for (int l = 0; l < left.Length; l++)
                {
                    bool isDigit = long.TryParse(left[l].ToString(), out long digit);
                    greaterLeft += digit;
                }
                for (int j = 0; j < right.Length; j++)
                {
                    bool isDigit = long.TryParse(right[j].ToString(), out long digit);
                    greaterRight += digit;
                }

                if (numberLeft > numberRight)
                {
                    Console.WriteLine(greaterLeft);
                }
                else
                {
                    Console.WriteLine(greaterRight);
                }

            }
        }
    }
}
