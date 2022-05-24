using System;

namespace _04_EasterShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int eggsQ = int.Parse(Console.ReadLine());
            int counterSoldEggs = 0;

            string input = Console.ReadLine();

            while (input != "Close")
            {
                int eggs = int.Parse(Console.ReadLine());

                if (input == "Buy")
                {
                    eggsQ -= eggs;
                    counterSoldEggs += eggs;
                    if (eggsQ < 0)
                    {
                        eggsQ += eggs;
                        Console.WriteLine($"Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggsQ}.");
                        break;
                    }
                }
                else if (input == "Fill")
                {
                    eggsQ += eggs;

                }
                input = Console.ReadLine();

            }
            if (input == "Close")
            {
                Console.WriteLine($"Store is closed!");
                Console.WriteLine($"{counterSoldEggs} eggs sold.");
            }

        }
    }
}
