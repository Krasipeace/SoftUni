using System;

namespace HappyCatParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double allCost = 0;

            for (int i = 1; i <= days; i++)
            {
                double cost = 0;
                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        cost += 2.50;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        cost += 1.25;
                    }
                    else
                    {
                        cost += 1.00;
                    }                    
                }
                allCost += cost;
                Console.WriteLine($"Day: {i} - {cost:f2} leva");
            }
            Console.WriteLine($"Total: {allCost:f2} leva");
        }
    }
}
