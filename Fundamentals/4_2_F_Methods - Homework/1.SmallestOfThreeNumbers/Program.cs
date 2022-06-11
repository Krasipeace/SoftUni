using System;

namespace _1.SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            PrintSmallestNum(num1, num2, num3);
        }

        static int PrintSmallestNum(int num1, int num2 , int num3)
        {
            int result = Math.Min(num1, Math.Min(num2, num3));
            Console.WriteLine($"{result}");
            return result;
        }
    }
}
