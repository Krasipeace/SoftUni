using System;

namespace _05_FitnessCenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int clients = int.Parse(Console.ReadLine());

            double counterBack = 0;
            double counterChest = 0;
            double counterLegs = 0;
            double counterAbs = 0;
            double counterShake = 0;
            double counterBar = 0;

            for (int i = 1; i <= clients; i++)
            {
                string activity = Console.ReadLine();

                if (activity == "Back")
                {
                    counterBack++;
                }
                else if (activity == "Chest")
                {
                    counterChest++;
                }
                else if (activity == "Legs")
                {
                    counterLegs++;
                }
                else if (activity == "Abs")
                {
                    counterAbs++;
                }
                else if (activity == "Protein shake")
                {
                    counterShake++;
                }
                else if (activity == "Protein bar")
                {
                    counterBar++;
                }
            }
            double pWorkOut = (counterBack + counterChest + counterLegs + counterAbs) / clients * 100.0;
            double pProtein = (counterShake + counterBar) / clients * 100.0; 

            Console.WriteLine($"{counterBack} - back");
            Console.WriteLine($"{counterChest} - chest");
            Console.WriteLine($"{counterLegs} - legs");
            Console.WriteLine($"{counterAbs} - abs");
            Console.WriteLine($"{counterShake} - protein shake");
            Console.WriteLine($"{counterBar} - protein bar");
            Console.WriteLine($"{pWorkOut:f2}% - work out");
            Console.WriteLine($"{pProtein:f2}% - protein");
        }
    }
}
