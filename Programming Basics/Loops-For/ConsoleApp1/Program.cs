using System;

namespace LeftRightSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumbers = int.Parse(Console.ReadLine());
            int firstSum = 0;
            int secondSum = 0;
            int diff = 0;
            for (int i = 1; i <= inputNumbers; i++)
            {
                firstSum = firstSum + int.Parse(Console.ReadLine());
            }
            for (int j = 1; j <= inputNumbers; j++)
            {
                secondSum = secondSum + int.Parse(Console.ReadLine());
            }
            if (firstSum == secondSum)
            {
                Console.WriteLine("Yes, sum = " + firstSum);
            }
            else
            {
                diff = Math.Abs(secondSum - firstSum);
                Console.WriteLine("No, diff = " + diff);
            }
        }
    }
}
