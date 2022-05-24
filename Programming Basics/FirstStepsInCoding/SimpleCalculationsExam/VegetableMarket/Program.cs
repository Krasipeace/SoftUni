using System;

namespace VegetableMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceVegetable = double.Parse(Console.ReadLine());
            double priceFruit = double.Parse(Console.ReadLine());
            int kgVegetable = int.Parse(Console.ReadLine());
            int kgFruit = int.Parse(Console.ReadLine());

            double result = ((priceVegetable * kgVegetable) + (priceFruit * kgFruit)) / 1.94;
            Console.WriteLine(result);
        }
    }
}
