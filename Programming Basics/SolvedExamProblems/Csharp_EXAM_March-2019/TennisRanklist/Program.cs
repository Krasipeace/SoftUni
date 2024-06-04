using System;

namespace TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournaments = int.Parse(Console.ReadLine());
            int rankPoints = int.Parse(Console.ReadLine());
            double counterW = 0;
            double counterF = 0;
            double counterSF = 0;
            double points = 0;

            for (int currentT = 1; currentT <= tournaments; currentT++)
            {
                string result = Console.ReadLine();
                if (result == "W")
                {
                    points += 2000;
                    counterW++;
                }
                else if (result == "F")
                {
                    points += 1200;
                    counterF++;
                }
                else if (result == "SF")
                {
                    points += 720;
                    counterSF++;
                }
            }
            double finalPoints = points + rankPoints;
            double averageP = points / tournaments;
            double wonT = counterW / tournaments * 100.0;
            
            Console.WriteLine($"Final points: {finalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(averageP)}");
            Console.WriteLine($"{wonT:f2}%");
        }
    }
}
