using System;

namespace WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordInSec = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secPerMeter = double.Parse(Console.ReadLine());
            double distanceOne = distance * secPerMeter;
            double secPerSlow = Math.Floor(distance / 15) * 12.5;
            double recordTrial = distanceOne + secPerSlow;
            if (recordInSec <= recordTrial)
            {
                double timeNeed = recordTrial - recordInSec;
                Console.WriteLine($"No, he failed! He was {timeNeed:f2} seconds slower.");
            }
            else if (recordInSec > recordTrial)
            {
                double timeNeed = distanceOne + secPerSlow;
                Console.WriteLine($"Yes, he succeeded! The new world record is {timeNeed:f2} seconds.");
            }
        }
    }
}
