using System;

namespace zad1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //combination of task1 + task2

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (i % 21 != 0)
                {
                    Console.WriteLine($"{i}");
                }
            }
        }
    }
}
