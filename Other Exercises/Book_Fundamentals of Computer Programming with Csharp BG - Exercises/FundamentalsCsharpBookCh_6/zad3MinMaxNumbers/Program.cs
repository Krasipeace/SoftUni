using System;

namespace zad3MinMaxNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int limit = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;
            for (int i = 1; i <= limit; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number >= maxNumber)
                {
                    maxNumber = number;
                }
                if (number <= minNumber)
                {
                    minNumber = number;
                }
            }
            Console.WriteLine($"Max number is: {maxNumber}");
            Console.WriteLine($"Min number is: {minNumber}");
        }
    }
}
