using System;

namespace _04_Darts
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string playerName = Console.ReadLine();
                        
            int markPoints = 301;
            double gamePoints = 0;
            int successCounter = 0;
            int failCounter = 0;
            double currentP = 0;

            while (gamePoints != markPoints)
            {
                string input = Console.ReadLine();
                if (input == "Retire")
                {
                    Console.WriteLine($"{playerName} retired after {failCounter} unsuccessful shots.");
                    break;
                }
                double points = double.Parse(Console.ReadLine());

                if (input == "Single")
                {
                    gamePoints += points;
                    currentP = points;
                    successCounter++;

                    if (gamePoints > markPoints)
                    {
                        gamePoints -= currentP;
                        failCounter++;
                        successCounter--;
                    }
                }
                else if (input == "Double")
                {
                    gamePoints += points * 2;
                    currentP = points;
                    successCounter++;

                    if (gamePoints > markPoints)
                    {
                        gamePoints -= currentP * 2;
                        failCounter++;
                        successCounter--;
                    }
                }
                else if (input == "Triple")
                {
                    gamePoints += points * 3;
                    currentP = points;
                    successCounter++;

                    if (gamePoints > markPoints)
                    {
                        gamePoints -= currentP * 3;
                        failCounter++;
                        successCounter--;
                    }
                }

                if (gamePoints == markPoints)
                {
                    Console.WriteLine($"{playerName} won the leg with {successCounter} shots.");
                    break;
                }

            }
        }
    }
}

