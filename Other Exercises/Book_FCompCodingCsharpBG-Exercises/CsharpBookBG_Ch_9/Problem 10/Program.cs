using System;  //factorials 1 ... 100
using System.Numerics;

namespace Problem_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            BigInteger factorial = 1;

            Console.WriteLine("Factorial of 1! = 1");
            for (int i = 2; i <= 100; i++)
            {
                factorial *= i;

                Console.WriteLine($"Factorial of {i}! = {factorial}");
            }           
        }
    }
}
