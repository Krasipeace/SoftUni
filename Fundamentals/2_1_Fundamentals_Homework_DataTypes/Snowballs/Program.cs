using System;
using System.Numerics;

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
            BigInteger bestValue = 0;

            for (int i = 1; i <= snowballAmount; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                double snowTime = snowballSnow / snowballTime;
                BigInteger snowballValue = (int)Math.Pow(snowTime, snowballQuality);

                if (snowballValue >= bestValue)
                {
                    bestValue = snowballValue;
                    bestSnow = snowballSnow;
                    bestQ = snowballQuality;
                    bestTime = snowballTime;
                }
            }
            Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQ})");

            //unfinished

        }
    }
}
