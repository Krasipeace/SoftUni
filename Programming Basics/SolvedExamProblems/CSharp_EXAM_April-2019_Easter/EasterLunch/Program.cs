using System;

namespace EasterLunch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int easterBread = int.Parse(Console.ReadLine());
            int eggsQ = int.Parse(Console.ReadLine());
            int cookiesQ = int.Parse(Console.ReadLine());

            double priceBread = easterBread * 3.20;
            double priceEggs = eggsQ * 4.35;
            double priceCookies = cookiesQ * 5.40;
            double eggsPaint = eggsQ * 12 * 0.15;

            double allCost = priceBread + priceEggs + priceCookies + eggsPaint;
            Console.WriteLine($"{allCost:f2}");
        }
    }
}
