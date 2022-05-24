using System;

namespace OddEvenSum3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;

            for (int i = 1; i <= inputNumber; i++)
            {
                int element = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += element;
                }
                else
                {
                    oddSum += element;
                }
            }
            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(oddSum - evenSum)}");
            }
        }
    }
}
