using System;

namespace Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int snowballAmount = int.Parse(Console.ReadLine());

            int bestSnow = 0;
            int bestTime = 0;
            int bestQ = 0;
            double bestValue = double.MinValue;

            for (int i = 1; i <= snowballAmount; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
               
                double snowballValue = Math.Pow(snowballSnow / snowballTime, snowballQuality);
                if (snowballValue > bestValue)
                {
                    bestValue = snowballValue;
                    bestSnow = snowballSnow;
                    bestQ = snowballQuality;
                    bestTime = snowballTime;
                }
            }
            Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQ})");

        }
    }
}
