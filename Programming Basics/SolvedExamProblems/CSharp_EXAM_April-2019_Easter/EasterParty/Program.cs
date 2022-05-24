using System;

namespace EasterParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            double pricePerson = double.Parse(Console.ReadLine());
            double budgetDessi = double.Parse(Console.ReadLine());
            double costBudget = 0.0;

            if (guests > 20)
            {
                costBudget = pricePerson * 0.75;
            }
            else if (guests <= 20 & guests > 15)
            {
                costBudget = pricePerson * 0.80;
            }
            else if (guests <= 15 & guests >= 10)
            {
                costBudget = pricePerson * 0.85;
            }
            else if (guests <= 9)
            {
                costBudget = pricePerson;
            }

            double costPpl = costBudget * guests;
            double cakePrice = budgetDessi * 0.10;
            double finalCost = cakePrice + costPpl;

            if (budgetDessi >= finalCost)
            {
                Console.WriteLine($"It is party time! {budgetDessi - finalCost:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {finalCost - budgetDessi:f2} leva needed.");
            }
        }
    }
}
