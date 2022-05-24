using System;

namespace FruitShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double strawberry = double.Parse(Console.ReadLine());
            double bananaQ = double.Parse(Console.ReadLine());
            double orangeQ = double.Parse(Console.ReadLine());
            double raspberryQ = double.Parse(Console.ReadLine());
            double strawberryQ = double.Parse(Console.ReadLine());

            double raspberry = strawberry * 0.50;
            double orange = raspberry * 0.60;
            double banana = raspberry * 0.20;

            double raspberryPrice = raspberry * raspberryQ;
            double orangePrice = orange * orangeQ;
            double bananaPrice = banana * bananaQ;
            double strawberryPrice = strawberry * strawberryQ;

            double result = raspberryPrice + bananaPrice + orangePrice + strawberryPrice;
            Console.WriteLine($"{result:f2}");

        }
    }
}
