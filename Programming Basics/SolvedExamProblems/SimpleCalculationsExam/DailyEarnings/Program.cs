using System;

namespace DailyEarnings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int workDays = int.Parse(Console.ReadLine());
            double wageUsd = double.Parse(Console.ReadLine());
            double usd = double.Parse(Console.ReadLine());

            double wageMonth = workDays * wageUsd;
            double wageYear = ((wageMonth * 12) + (wageMonth * 2.5));
            double tax = wageYear * 0.25;
            double wage = wageYear - tax;
            double wageBgn = wage * usd;
            double wageAverage = wageBgn / 365;
            Console.WriteLine($"{wageAverage:f2}");
        }
    }
}
