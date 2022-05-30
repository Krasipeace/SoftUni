using System;

namespace zad10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());          
            for (int i = 1; i <= n; i++)
            {               

                for (int j = i; j <= n + 1; j++)
                {
                    Console.Write($"{j} ");                    
                }
                Console.WriteLine(i);
            }
        }
    }
}
