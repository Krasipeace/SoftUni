using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();
            int potatoPasses = int.Parse(Console.ReadLine());

            Queue<string> players = new Queue<string>(kids);

            int counter = 1;

            while (players.Count > 1)
            {
                string potatoCarrier = players.Dequeue();
                if (counter != potatoPasses)
                {
                    players.Enqueue(potatoCarrier);
                    counter++;
                }
                else
                {
                    counter = 1;
                    Console.WriteLine($"Removed {potatoCarrier}");
                }
            }
            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}
