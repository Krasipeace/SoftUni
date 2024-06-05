using System;

namespace GodzillaVSKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budgetMovie = double.Parse(Console.ReadLine());
            int walkerNumber = int.Parse(Console.ReadLine());
            double walkerApparel = double.Parse(Console.ReadLine());
            double decorMovie = budgetMovie * 0.10;  
            if (walkerNumber > 150)
            {
                walkerApparel = walkerApparel - (walkerApparel / 10);
            }
            double costMovie = decorMovie + (walkerApparel * walkerNumber);
            double moneyNeed = budgetMovie - costMovie;
            if (costMovie > budgetMovie)
            {
                Console.WriteLine("Not enough money!");               
                Console.WriteLine($"Wingard needs {Math.Abs(moneyNeed):f2} leva more.");
            }
            else if (costMovie <= budgetMovie)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyNeed:f2} leva left.");
            }
        }
    }
}
