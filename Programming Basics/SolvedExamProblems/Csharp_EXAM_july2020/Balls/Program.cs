using System;

namespace Balls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ballsQ = int.Parse(Console.ReadLine());
            int points = 0;
            int counterRed = 0;
            int counterOrange = 0;
            int counterYellow = 0;
            int counterWhite = 0;
            int counterBlack = 0;
            int counterOther = 0;

            for (int i = 1; i <= ballsQ; i++)
            {
                string color = Console.ReadLine(); // red + 5 | orange + 10 | yellow + 15 | white + 20 | black = points / 2 
                if (color == "red")
                {
                    points += 5;
                    counterRed++;
                }
                else if (color == "orange")
                {
                    points += 10;
                    counterOrange++;
                }
                else if (color == "yellow")
                {
                    points += 15;
                    counterYellow++;
                }
                else if (color == "white")
                {
                    points += 20;
                    counterWhite++;
                }
                else if (color == "black")
                {
                    points = points / 2;
                    counterBlack++;
                }
                else
                {
                    counterOther++;
                }
            }
            Console.WriteLine($"Total points: {points}");
            Console.WriteLine($"Red balls: {counterRed}");
            Console.WriteLine($"Orange balls: {counterOrange}");
            Console.WriteLine($"Yellow balls: {counterYellow}");
            Console.WriteLine($"White balls: {counterWhite}");
            Console.WriteLine($"Other colors picked: {counterOther}");
            Console.WriteLine($"Divides from black balls: {counterBlack}");
        }
    }
}
