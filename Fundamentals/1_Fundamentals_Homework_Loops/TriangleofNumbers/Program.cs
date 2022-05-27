using System;

namespace TriangleofNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i - 1; j++)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine(i);
            }
        }
    }
}
