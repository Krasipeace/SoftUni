using System;

namespace MountainRun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

            double timeToSpend = distance * timePerMeter;
            double fatigue = Math.Floor(distance / 50);
            fatigue = fatigue * 30;
            double allTime = timeToSpend + fatigue;
            if (allTime < record)
            {
                Console.WriteLine($"Yes! The new record is {allTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {Math.Abs(allTime - record):f2} seconds slower.");
            }
        }
    }
}
