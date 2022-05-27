using System;

namespace SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sum = 0;
            int digit = 0;
            bool specialNumber = false;

            for (int currentNumber = 1; currentNumber <= input; currentNumber++)
            {
                digit = currentNumber;

                while (currentNumber > 0)
                {
                    sum += currentNumber % 10;
                    currentNumber = currentNumber / 10;
                }

                specialNumber = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{digit} -> {specialNumber}");
                sum = 0;
                currentNumber = digit;

            }
        }
    }
}
