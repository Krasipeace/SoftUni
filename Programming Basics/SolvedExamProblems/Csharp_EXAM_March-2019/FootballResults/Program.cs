using System;

namespace FootballResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string matchFirst = Console.ReadLine();
            string matchSecond = Console.ReadLine();
            string matchThird = Console.ReadLine();

            int matchesWon = 0;
            int matchesLost = 0;
            int matchesEqual = 0;

            int matchFirstResultF = matchFirst[0];
            int matchSecondResultF = matchFirst[2];
            if (matchFirstResultF > matchSecondResultF)
            {
                matchesWon++;
            }
            else if (matchFirstResultF == matchSecondResultF)
            {
                matchesEqual++;
            }
            else
            {
                matchesLost++;
            }

            int matchFirstResultS = matchSecond[0];
            int matchSecondResultS = matchSecond[2];
            if (matchFirstResultS > matchSecondResultS)
            {
                matchesWon++;
            }
            else if (matchFirstResultS == matchSecondResultS)
            {
                matchesEqual++;
            }
            else
            {
                matchesLost++;
            }

            int matchFirstResultT = matchThird[0];
            int matchSecondResultT = matchThird[2];
            if (matchFirstResultT > matchSecondResultT)
            {
                matchesWon++;
            }
            else if (matchFirstResultT == matchSecondResultT)
            {
                matchesEqual++;
            }
            else
            {
                matchesLost++;
            }

            Console.WriteLine($"Team won {matchesWon} games.");
            Console.WriteLine($"Team lost {matchesLost} games.");
            Console.WriteLine($"Drawn games: {matchesEqual}");

        }
    }
}
