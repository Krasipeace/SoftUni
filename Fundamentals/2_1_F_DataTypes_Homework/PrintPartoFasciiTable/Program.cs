using System;

namespace PrintPartoFasciiTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte start = byte.Parse(Console.ReadLine());
            byte end = byte.Parse(Console.ReadLine());
            char symbol = '0';

            for (int i = start; i <= end; i++)
            {
                symbol = (char)i;
                Console.Write($"{symbol} ");
            }
        }
    }
}
