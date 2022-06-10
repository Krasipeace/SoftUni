using System;

namespace _4.TribonacciSequence  //first attempt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                System.Environment.Exit(0);
            }
            PrintTribo(number);

        }

        static int PrintTribReccursion(int number)
        {
            if (number <= 2)
            {
                return 1;
            }

            if (number == 3)
            {
                return 2;
            }
            else
            {
                return PrintTribReccursion(number - 1) + PrintTribReccursion(number - 2) + PrintTribReccursion(number - 3);
            }

        }

        static void PrintTribo(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                Console.Write($"{PrintTribReccursion(i)} ");
            }
        }
    }
}
