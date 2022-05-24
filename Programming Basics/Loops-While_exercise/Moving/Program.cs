using System;

namespace Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boxWidth = int.Parse(Console.ReadLine());
            int boxLength = int.Parse(Console.ReadLine());
            int boxHeight = int.Parse(Console.ReadLine());
            int box = boxWidth * boxLength * boxHeight;

            string input = Console.ReadLine();
            int takeBox = 0;

            while (input != "Done")
            {
                int cubicBox = int.Parse(input);
                takeBox += cubicBox;
                if (takeBox > box)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(takeBox - box)} Cubic meters more.");
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "Done")
            {
                Console.WriteLine($"{box - takeBox} Cubic meters left.");
            }
        }
    }
}
