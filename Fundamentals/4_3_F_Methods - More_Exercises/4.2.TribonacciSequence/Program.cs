using System;
using System.Numerics;

namespace _4._2.TribonacciSequence //3rd attempt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());

            if (number <= 0)
            {
                Console.Write(0);
            }
            else if (number == 1)
            {
                Console.Write(1);
            }
            else if (number == 2)
            {
                Console.Write("1 1");
            }
            else if (number == 3)
            {
                Console.Write("1 1 2");
            }
            else
            {
                Console.Write("1 1 2 ");
                PrintTribo(number);
            }
        }

        private static void PrintTribo(BigInteger number)
        {
            BigInteger minus3 = 1;
            BigInteger minus2 = 1;
            BigInteger minus1 = 2;
            BigInteger maxNumber = number;

            for (int i = 0; i < maxNumber - 3; i++)
            {
                number = minus3 + minus2 + minus1;
                minus3 = minus2;
                minus2 = minus1;
                minus1 = number;

                Console.Write($"{number} ");
            }
        }
    }
}
