using System;

namespace _06_NameGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int charLetter = 0;
            int MaxScore = 0;
            string WinnerName = string.Empty; 

            while (name != "Stop")
            {
                int currentScore = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    charLetter = (int)name[i];

                    int n = int.Parse(Console.ReadLine());

                    if (charLetter == n)
                    {
                        currentScore = currentScore + 10;
                    }
                    else
                    {
                        currentScore = currentScore + 2;
                    }

                    if (currentScore >= MaxScore) 
                    {
                        MaxScore = currentScore;
                        WinnerName = name;
                    }
                }

                name = (Console.ReadLine());
            }

            Console.WriteLine($"The winner is {WinnerName} with {MaxScore} points!");
        }
    }
}
