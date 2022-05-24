using System;

namespace GodzillavsKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budgetMovie = double.Parse(Console.ReadLine());
            int extraActors = int.Parse(Console.ReadLine());
            double extraDress = double.Parse(Console.ReadLine());

            double movieDecor = budgetMovie * 0.10;
            double allDress = extraActors * extraDress;

            if (extraActors > 150)
            {
                allDress = allDress - allDress * 0.10;
            }
            double allExpense = allDress + movieDecor;

            if (allExpense > budgetMovie)
            {
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {allExpense - budgetMovie:f2} leva more.");
            }
            else
            {
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {budgetMovie - allExpense:f2} leva left.");
            }
            
        }
    }
}
