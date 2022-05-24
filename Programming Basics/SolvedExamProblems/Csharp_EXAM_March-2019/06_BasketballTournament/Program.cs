using System;

namespace _06_BasketballTournament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameT = Console.ReadLine();
            double counterW = 0;
            double counterL = 0;
            double counterMatches = 0;

            while (nameT != "End of tournaments")
            {
                int matches = int.Parse(Console.ReadLine());
                counterMatches++;
                for (int playerN = 1; playerN <= matches; playerN++)
                {
                    int desiPoints = int.Parse(Console.ReadLine());
                    int foePoints = int.Parse(Console.ReadLine());
                    if (desiPoints > foePoints)
                    {
                        counterW++;
                        Console.WriteLine($"Game {playerN} of tournament {nameT}: win with {desiPoints - foePoints} points.");
                    }
                    else
                    {
                        counterL++;
                        Console.WriteLine($"Game {playerN} of tournament {nameT}: lost with {foePoints - desiPoints} points.");
                    }                        
                }
                nameT = Console.ReadLine();
            }
            double pWin = counterW / counterMatches * 100.0;
            double pLose = counterL / counterMatches * 100.0;
            if (nameT == "End of tournaments")
            {
                Console.WriteLine($"{pWin:f2}% matches win");
            }
            else
            {
                Console.WriteLine($"{pLose:f2}% matches lost");
            }
                       
        }
    }
}
