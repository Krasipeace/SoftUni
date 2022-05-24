using System;

namespace SeriesCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movieTitle = Console.ReadLine();
            int seasons = int.Parse(Console.ReadLine());
            int episodes = int.Parse(Console.ReadLine());
            double epNoAds = double.Parse(Console.ReadLine());

            double epWithAds = epNoAds + epNoAds * 0.20;
            double specialEps = seasons * 10;
            double allTime = Math.Floor(epWithAds * episodes * seasons + specialEps);

            Console.WriteLine($"Total time needed to watch the {movieTitle} series is {allTime} minutes.");
        }
    }
}
