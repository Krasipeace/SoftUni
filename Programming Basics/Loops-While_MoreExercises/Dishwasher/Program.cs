using System;

namespace Dishwasher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int detergentQ = input * 750;
            string type = string.Empty;
            int counter = 0;
            int potCounter = 0;
            int dishCounter = 0;

            while (true)
            {
                type = Console.ReadLine();
                if (type == "End")
                {
                    Console.WriteLine($"Detergent was enough!");
                    Console.WriteLine($"{dishCounter} dishes and {potCounter} pots were washed.");
                    Console.WriteLine($"Leftover detergent {detergentQ} ml.");
                    break;
                }
                counter++;
                input = int.Parse(type);
                if (counter % 3 == 0)
                {
                    //pot
                    potCounter += input;
                    detergentQ -= 15 * input;
                    if (detergentQ < 0)
                    {
                        Console.WriteLine($"Not enough detergent, {Math.Abs(detergentQ)} ml. more necessary!");
                        break;
                    }
                }
                else
                {
                    //dish
                    dishCounter += input;
                    detergentQ -= 5 * input;
                    if (detergentQ < 0)
                    {
                        Console.WriteLine($"Not enough detergent, {Math.Abs(detergentQ)} ml. more necessary!");
                        break;
                    }
                }
            }              
        }
    }
}
