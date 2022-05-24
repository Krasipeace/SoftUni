using System;

namespace FootballLeague
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            int fans = int.Parse(Console.ReadLine());
            double sectorA = 0.0;
            double sectorB = 0.0;
            double sectorV = 0.0;
            double sectorG = 0.0;
            for (int i = 1; i <= fans; i++)
            {
                char sector = char.Parse(Console.ReadLine());    
                if (sector == 'A')  
                {
                    sectorA += 1;
                }
                else if (sector == 'B') 
                {
                    sectorB += 1;
                }
                else if (sector == 'V')  
                {
                    sectorV += 1;
                }
                else if (sector == 'G') 
                {
                    sectorG += 1;
                }
            }
            double pSectors = (sectorA + sectorB + sectorV + sectorG) / capacity * 100.0;
            sectorA = sectorA / fans * 100.0;
            sectorB = sectorB / fans * 100.0;
            sectorV = sectorV / fans * 100.0;
            sectorG = sectorG / fans * 100.0;
            Console.WriteLine($"{sectorA:f2}%");
            Console.WriteLine($"{sectorB:f2}%");
            Console.WriteLine($"{sectorV:f2}%");
            Console.WriteLine($"{sectorG:f2}%");
            Console.WriteLine($"{pSectors:f2}%");
        }
    }
}
