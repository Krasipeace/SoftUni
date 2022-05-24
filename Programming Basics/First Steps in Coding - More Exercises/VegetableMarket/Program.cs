using System;

namespace VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            //въвеждане на стойности
            double priceVegetable = double.Parse(Console.ReadLine());
            double priceFruit = double.Parse(Console.ReadLine());
            int kgVegetable = int.Parse(Console.ReadLine());
            int kgFruit = int.Parse(Console.ReadLine());
            //изчисления
            double incomeVegetable = priceVegetable * kgVegetable;
            double incomeFruit = priceFruit * kgFruit;
            double incomeAll = incomeVegetable + incomeFruit;
            //конветиране в евро (по задание курс: 1.94)
            double result = incomeAll / 1.94;
            Console.WriteLine("{0:f2}", result);
        }
    }
}