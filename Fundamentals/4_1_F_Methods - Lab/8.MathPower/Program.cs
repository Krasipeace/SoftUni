using System;

namespace _8.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double baseNumber = double.Parse(Console.ReadLine());
            int powerNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(MathPower(baseNumber, powerNumber));
        }

        static double MathPower(double baseNumber, int powerNumber)
        {
            double result = 1;

            for (int i = 0; i < powerNumber; i++)
            {
                result *= baseNumber;
            }

            return result;
        }
    }
}
