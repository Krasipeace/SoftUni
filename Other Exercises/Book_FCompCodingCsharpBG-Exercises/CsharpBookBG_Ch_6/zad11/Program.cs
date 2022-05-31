using System;
using System.Numerics;

namespace zad11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Програма, която пресмята с колко нули завършва факториелът на дадено число.

            BigInteger numberFact = BigInteger.Parse(Console.ReadLine());
            BigInteger input = numberFact;

            for (BigInteger i = numberFact - 1; i > 0; i--)
            {
                numberFact *= i;
            }
            Console.WriteLine($"The factorial of {input} is: {numberFact}");
            int counter = 0;

            while (numberFact % 10 == 0)
            {
                counter++;
                numberFact /= 10;
            }
            Console.WriteLine($"At the end of the factorial there is/are {counter} zero/es.");

        }

    }
}
