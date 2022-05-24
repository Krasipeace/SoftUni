using System;

namespace Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double budget = 0;

            while (destination != "End")
            {
                double destinationBudget = double.Parse(Console.ReadLine());
                while (true)
                {
                    double savedMoney = double.Parse(Console.ReadLine());
                    budget += savedMoney;
                    if (budget >= destinationBudget)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                }
                budget = 0;
                destination = Console.ReadLine();
            }
        }        
    }
}
