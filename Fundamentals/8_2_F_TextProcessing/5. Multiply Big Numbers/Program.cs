using System;
using System.Numerics;

namespace _5._Multiply_Big_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger inputNumber = BigInteger.Parse(Console.ReadLine());
            byte multiplier = byte.Parse(Console.ReadLine());

            Console.WriteLine(inputNumber * multiplier);
        }
    }
}
