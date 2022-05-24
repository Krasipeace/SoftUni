using System;

namespace ChangeBureau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double yuans = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());
            
            double bitcoinLev = bitcoins * 1168.0;
            double yuansDollars = yuans * 0.15;
            double yuansLev = yuansDollars * 1.76;
            double euros = (bitcoinLev + yuansLev) / 1.95;
            double cash = euros - euros * commission / 100;

            Console.WriteLine($"{cash:f2}");
        }
    }
}
