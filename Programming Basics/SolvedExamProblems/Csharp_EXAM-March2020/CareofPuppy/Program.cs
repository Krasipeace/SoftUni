using System;

namespace CareofPuppy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int packets = int.Parse(Console.ReadLine());
            int foodQ = packets * 1000;
            string input = Console.ReadLine();
            int foodEaten;
            int allfood = 0;
            while (input != "Adopted")
            {                
                foodEaten = int.Parse(input);
                allfood += foodEaten;

                input = Console.ReadLine();
            }
            if (allfood <= foodQ)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodQ - allfood} grams.");                
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {Math.Abs(allfood - foodQ)} grams more.");                
            }
        }
    }
}
