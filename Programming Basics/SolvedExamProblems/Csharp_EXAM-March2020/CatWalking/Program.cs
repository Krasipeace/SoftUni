using System;

namespace CatWalking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int walkTime = int.Parse(Console.ReadLine());
            int walkNum = int.Parse(Console.ReadLine());
            int catCal = int.Parse(Console.ReadLine());

            int catWalks = walkTime * walkNum;
            int burnCal = catWalks * 5;
            double burnNeed = catCal * 0.50;

            if (burnCal >= burnNeed)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burnCal}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {burnCal}.");
            }
            
        }
    }
}
