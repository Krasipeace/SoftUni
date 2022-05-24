using System;

namespace TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfTournaments = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());          
            int points = startPoints;
            double numOfWins = 0.0;
            
            for (int i = 1; i <= numOfTournaments; i++)
            {
                string typeOfTournament = Console.ReadLine();
                if (typeOfTournament == "W")
                {
                    points += 2000;
                    numOfWins += 1;
                }
                else if (typeOfTournament == "F")
                {
                    points += 1200;
                }
                else if (typeOfTournament == "SF")
                {
                    points += 720;
                }
            }
            Console.WriteLine($"Final points: {points}");
            points = points - startPoints;
            double averagePoints = points / numOfTournaments;
            double avgWins = numOfWins / numOfTournaments * 100.0;
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{avgWins:f2}%");
        }
    }
}
