using System;

namespace Refactoring_PrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int currentNumber = 2; currentNumber <= n; currentNumber++)
            {
                bool isPrime = true;
                for (int checker = 2; checker < currentNumber; checker++)
                {
                    if (currentNumber % checker == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }      
                if (!isPrime)
                {
                    Console.WriteLine($"{currentNumber} -> false");
                }
                else
                {
                    Console.WriteLine($"{currentNumber} -> true");
                }
            }
        }
    }
}
