using System;

namespace BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte inputLines = byte.Parse(Console.ReadLine());
            double currentKeg = 0.0;
            double biggestKeg = 0.0;
            string kegWinner = string.Empty;

            for (int i = 1; i <= inputLines; i++)
            {
                string kegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());
                currentKeg = Math.PI * (kegRadius * kegRadius) * kegHeight;
                if (currentKeg > biggestKeg)
                {
                    biggestKeg = currentKeg;
                    kegWinner = kegModel;
                }
            }
            Console.WriteLine(kegWinner);            
        }
    }
}
