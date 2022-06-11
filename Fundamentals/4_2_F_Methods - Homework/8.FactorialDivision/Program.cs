using System;

namespace _8.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            
            FactorialOne(numberOne);
            FactorialTwo(numberTwo);
            PrintFactorialDivision(numberOne, numberTwo);
        }

        private static void PrintFactorialDivision(double numberOne, double numberTwo)
        {
            Console.WriteLine($"{FactorialOne(numberOne) / FactorialTwo(numberTwo):f2}");
        }

        private static double FactorialTwo(double numberTwo)
        {
            double numberTwoFact = 1;
            for (int i = 1; i <= numberTwo; i++)
            {
                numberTwoFact *= i;
            }
            numberTwo = numberTwoFact;
            return numberTwo;
        }

        private static double FactorialOne(double numberOne)
        {
            double numberOneFact = 1;
            for (int i = 1; i <= numberOne; i++)
            {
                numberOneFact *= i;
            }
            numberOne = numberOneFact;
            return numberOne;
        }
    }
}
