using System;

namespace HalfSumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;
            for (int i = 0; i < inputNumber; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum = sum + number;
                if (number > max)
                {
                    max = number;
                }
            }
            int sumNoMax = sum - max;
            if (max == sumNoMax)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                int diff = Math.Abs(max - sumNoMax);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
