using System;
using System.Linq;

namespace _4._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(double.Parse)
                                                .Select(num => num * 1.20)
                                                .ToArray();
            foreach (var item in prices)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
