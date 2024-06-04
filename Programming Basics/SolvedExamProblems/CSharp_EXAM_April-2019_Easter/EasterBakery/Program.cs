using System;

namespace EasterBakery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double flourPrice = double.Parse(Console.ReadLine());
            double flourQ = double.Parse(Console.ReadLine());
            double sugarQ = double.Parse(Console.ReadLine());
            int eggsQ = int.Parse(Console.ReadLine());
            int yeastQ = int.Parse(Console.ReadLine());

            double flour = flourPrice * flourQ;
            double sugarPrice = flourPrice * 0.75;
            double eggsPrice = flourPrice * 1.10;
            double yeastPrice = sugarPrice * 0.20;

            double sugarSum = sugarQ * sugarPrice;
            double eggsSum = eggsQ * eggsPrice;
            double yeastSum = yeastQ * yeastPrice;

            double allCost = flour + sugarSum + eggsSum + yeastSum;
            Console.WriteLine($"{allCost:f2}");
        }
    }
}
