using System;

namespace Skeleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            int seconds100 = int.Parse(Console.ReadLine());

            int controlTime = (minutes * 60) + seconds;
            double timeSlow = meters / 120 * 2.5;
            double marinTime = (meters / 100 * seconds100) - timeSlow;

            if (marinTime <= controlTime)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {marinTime:f3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {Math.Abs(controlTime - marinTime):f3} second slower.");
            }

        }
    }
}
