using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split("@", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split().ToArray();
            int currentHouse = 0;

            while (command[0] != "Love!")
            {
                int jump = int.Parse(command[1]);

                currentHouse = CupidJump(neighborhood, currentHouse, jump);

                neighborhood[currentHouse] -= 2;

                CheckHouse(neighborhood, currentHouse);

                command = Console.ReadLine().Split();
            }
            Console.WriteLine($"Cupid's last position was {currentHouse}.");
            Console.WriteLine(neighborhood.All(house => house <= 0) 
                            ? "Mission was successful."
                            : $"Cupid has failed {neighborhood.Count(house => house > 0)} places.");
        }

        private static void CheckHouse(int[] neighborhood, int currentHouse)
        {
            if (neighborhood[currentHouse] == 0)
            {
                Console.WriteLine($"Place {currentHouse} has Valentine's day.");
            }
            if (neighborhood[currentHouse] < 0)
            {
                Console.WriteLine($"Place {currentHouse} already had Valentine's day.");
            }
        }

        private static int CupidJump(int[] neighborhood, int currentHouse, int jump)
        {
            if (currentHouse + jump >= neighborhood.Length)
            {
                currentHouse = 0;
            }
            else
            {
                currentHouse += jump;
            }

            return currentHouse;
        }
    }
}

