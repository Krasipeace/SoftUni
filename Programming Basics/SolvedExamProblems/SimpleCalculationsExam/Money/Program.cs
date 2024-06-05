using System;

namespace Money
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double yuans = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());
            commission = commission / 100;

            double bitcoinBgn = bitcoins * 1168;
            double yuansBgn = (yuans * 0.15) * 1.76;
            double cashEuro = (bitcoinBgn + yuansBgn) / 1.95;
            double cashResult = cashEuro - (cashEuro * commission);
            Console.WriteLine(cashResult);
        }
    }
}
