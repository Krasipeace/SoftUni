using System;

namespace _05_DivisionWithoutRemainder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int number;
            double counterTwo = 0;
            double counterThree = 0;
            double counterFour = 0;

            for (int i = 1; i <= numbers; i++)
            {
                number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    counterTwo++;
                }
                if (number % 3 == 0)
                {
                    counterThree++;
                }
                if (number % 4 == 0)
                {
                    counterFour++;
                }
            }
            double pTwo = counterTwo / numbers * 100.0;
            double pThree = counterThree / numbers * 100.0;
            double pFour = counterFour / numbers * 100.0;
            Console.WriteLine($"{pTwo:f2}%");
            Console.WriteLine($"{pThree:f2}%");
            Console.WriteLine($"{pFour:f2}%");
        }
    }
}
