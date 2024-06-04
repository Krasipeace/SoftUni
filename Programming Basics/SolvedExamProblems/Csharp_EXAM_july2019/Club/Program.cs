using System;

namespace Club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = int.Parse(Console.ReadLine());
            string coctailName = Console.ReadLine();
            int coctailPrice = 0;
            int coctailAmount = 0;
            double profitCoctail = 0;
            double income = 0;

            while (coctailName != "Party!")
            {

                coctailPrice = coctailName.Length;
                coctailAmount = int.Parse(Console.ReadLine());
                profitCoctail = coctailPrice * coctailAmount;

                if (profitCoctail % 2 != 0)
                {
                    profitCoctail = profitCoctail - profitCoctail * 0.25;
                }
                income += profitCoctail;
                if (income >= money)
                {
                    Console.WriteLine($"Target acquired.");
                    Console.WriteLine($"Club income - {income:f2} leva.");
                    break;
                }
                coctailName = Console.ReadLine();
                if (coctailName == "Party!")
                {
                    Console.WriteLine($"We need {Math.Abs(money - income):f2} leva more.");
                    Console.WriteLine($"Club income - {income:f2} leva.");
                    break;
                }
            }
        }
    }
}
