using System;

namespace TournamentofChristmas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            int winDays = 0;
            int loseDays = 0;            
            double profitT = 0;

            for (int i = 1; i <= days; i++)
            {
                double profit = 0;
                int winCounter = 0;
                int loseCounter = 0;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "Finish")
                    {
                        break;
                    }
                    string type = Console.ReadLine();

                    if (type == "win")
                    {
                        winCounter++;
                        profit += 20;
                    }
                    else if (type == "lose")
                    {
                        loseCounter++;
                    }
                }

                if (winCounter > loseCounter)
                {
                    profit += profit * 0.10;
                    winDays++;
                }
                else
                {
                    loseDays++;
                }
                profitT += profit;
            }

            if (winDays > loseDays)
            {
                profitT += profitT * 0.20;
                Console.WriteLine($"You won the tournament! Total raised money: {profitT:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {profitT:f2}");
            }
        }
    }
}
