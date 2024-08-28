using System;

namespace _06_EasterCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int easterBreadQ = int.Parse(Console.ReadLine());
            int maxScore = int.MinValue;
            string bestChef = string.Empty;
            
            for (int i = 1; i <= easterBreadQ; i++)
            {
                int chefScore = 0;                
                string chef = Console.ReadLine();
                string input = Console.ReadLine();

                while (input != "Stop")
                {
                    chefScore += int.Parse(input);
                    input = Console.ReadLine();
                }
                Console.WriteLine($"{chef} has {chefScore} points.");

                if (chefScore > maxScore)
                {
                    maxScore = chefScore;
                    bestChef = chef;
                    Console.WriteLine($"{chef} is the new number 1!");
                }                                                 
            }
            Console.WriteLine($"{bestChef} won competition with {maxScore} points!");
        }
    }
}
