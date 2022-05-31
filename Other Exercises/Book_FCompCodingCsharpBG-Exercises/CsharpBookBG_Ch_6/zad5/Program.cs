using System;

namespace zad5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int first = 0;
            int second = 1;

            Console.Write($"{first} {second} ");

            for (int i = 2; i <= n; i++)
            {
                int three = first + second;
                Console.Write($"{three} ");
                first = second;
                second = three;

            }
 
        }
    }
}
