using System;

namespace zad9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // s = (1 + (1! / x) + (2! / x^2) + ... + (n! / x^n))
            Console.Write("Enter X: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            int s = 1;
            int nx = 1;

            for (int i = 1; i <= n; i++)
            {
                nx *= i / x;
                s += nx;
            }
            Console.WriteLine($"S = {s}");
        }
    }
}
