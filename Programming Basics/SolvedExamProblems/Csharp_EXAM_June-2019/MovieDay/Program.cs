using System;

namespace MovieDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int timePics = int.Parse(Console.ReadLine());
            int scenes = int.Parse(Console.ReadLine());
            int sceneTime = int.Parse(Console.ReadLine());

            double terrain = timePics * 0.15;
            double sceneallT = sceneTime * scenes;
            double timeNeed = terrain + sceneallT;

            if (timeNeed > timePics)
            {
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(timeNeed - timePics)} minutes.");
            }
            else
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(timePics - timeNeed)} minutes left!");
            }
        }
    }
}
