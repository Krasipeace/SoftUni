using System;

namespace EasterGuests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double guests = double.Parse(Console.ReadLine());
            double budgetLubo = double.Parse(Console.ReadLine());
 
            double easterBreadQ = Math.Ceiling(guests / 3);
            double eggsQ = guests * 2;

            double costBread = 4.00 * easterBreadQ;
            double costEggs = 0.45 * eggsQ;
            double costs = costBread + costEggs;
            
            if (budgetLubo >= costs)
            {
                Console.WriteLine($"Lyubo bought {easterBreadQ} Easter bread and {eggsQ} eggs.");
                Console.WriteLine($"He has {budgetLubo - costs:f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {costs - budgetLubo:f2} lv. more.");
            }

        }
    }
}
