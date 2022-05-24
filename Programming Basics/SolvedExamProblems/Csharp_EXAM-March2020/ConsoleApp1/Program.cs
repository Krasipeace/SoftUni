using System;

namespace Christmas_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayCount = int.Parse(Console.ReadLine());

            int dayWin = 0;
            int dayLose = 0;
            double allProfit = 0;

            for (int i = 1; i <= dayCount; i++)
            {
                int countWinGames = 0;
                int countLoseGames = 0;
                double dayProfit = 0;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "Finish")
                    {
                        break;
                    }
                    string result = Console.ReadLine();
                    if (result == "win")
                    {
                        countWinGames++;
                        dayProfit += 20;
                    }
                    else if (result == "lose")
                    {
                        countLoseGames++;
                    }
                }
                if (countWinGames > countLoseGames)
                {
                    dayProfit *= 1.1;
                    dayWin++;
                }
                else
                {
                    dayLose++;
                }
                allProfit += dayProfit;
            }
            if (dayWin > dayLose)
            {
                allProfit *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {allProfit:F2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {allProfit:F2}");
            }
        }
    }
}
