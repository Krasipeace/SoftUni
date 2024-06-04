using System;

namespace FootballTournament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int games = int.Parse(Console.ReadLine());
            char result;
            double counterW = 0; //победи
            int counterD = 0; //равни
            int counterL = 0; //загуби
            double points = 0;

            if (games == 0)
            {
                Console.WriteLine($"{name} hasn't played any games during this season.");
                return;
            }
            for (int i = 1; i <= games; i++)
            {
                result = char.Parse(Console.ReadLine());
                if (result == 'W')
                {
                    points += 3;
                    counterW++;
                }
                else if (result == 'D')
                {
                    points += 1;
                    counterD++;
                }
                else if (result == 'L')
                {
                    counterL++;
                }
            }

            double winrate = counterW / games * 100.0;
            if (games > 0)
            {
                Console.WriteLine($"{name} has won {points} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {counterW}");
                Console.WriteLine($"## D: {counterD}");
                Console.WriteLine($"## L: {counterL}");
                Console.WriteLine($"Win rate: {winrate:f2}%");
            }
        }
    }
}
