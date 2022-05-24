using System;

namespace PrimePairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int firstDif = int.Parse(Console.ReadLine());
            int secondDif = int.Parse(Console.ReadLine());

            for (int a = firstNum; a <= firstNum + firstDif; a++)
            {
                for (int b = secondNum; b <= secondNum + secondDif; b++)
                {
                    if (a % 2 != 0 && a % 3 != 0 && a % 5 != 0 && a % 7 != 0 && b % 2 != 0 && b % 3 != 0 && b % 5 != 0 && b % 7 != 0)
                    {
                        Console.WriteLine($"{a}{b}");
                    }
                }
            }
        }
    }
}
