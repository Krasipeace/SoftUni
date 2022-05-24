using System;

namespace EqualSumsEvenOddPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());

            for (int num = numOne; num <= numTwo; num++)
            {
                int oddSum = 0;
                int evenSum = 0;
                string currentDigit = num.ToString();
                for (int i = 0; i < currentDigit.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        evenSum += currentDigit[i];
                    }
                    else
                    {
                        oddSum += currentDigit[i];
                    }
                }
                if (oddSum == evenSum)
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}
