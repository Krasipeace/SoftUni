using System;

namespace PoundsToDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pounds = double.Parse(Console.ReadLine());
            decimal dollars = Convert.ToDecimal(1.31 * pounds);
            Console.WriteLine($"{dollars:f3}");
        }
    }
}
