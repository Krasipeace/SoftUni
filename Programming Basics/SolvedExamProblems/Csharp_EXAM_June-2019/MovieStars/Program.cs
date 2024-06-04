using System;

namespace MovieStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            bool endBudget = false;
            while (command != "ACTION")
            {
                string actor = command;
                double salary = 0;
                if (actor.Length <= 15)
                {
                    salary = double.Parse(Console.ReadLine());
                }
                else
                {
                    salary = 0.20 * budget;
                }
                budget -= salary;
                if (budget <= 0)
                {
                    Console.WriteLine($"We need {Math.Abs(budget):f2} leva for our actors.");
                    endBudget = true;
                    break;
                }

                command = Console.ReadLine();
            }
            if (!endBudget)
            {
                Console.WriteLine($"We are left with {budget:F2} leva.");
            }
        }
    }
}
