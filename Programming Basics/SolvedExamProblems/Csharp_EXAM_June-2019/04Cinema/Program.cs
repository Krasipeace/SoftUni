using System;

namespace _04Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hall = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int peopleInHall = 0;
            double income = 0;
            double allIncome = 0;

            bool fullhall = false;
            while (input != "Movie Time!")
            {
                int clients = int.Parse(input);                
                peopleInHall += clients;

                if (peopleInHall > hall)
                {
                    Console.WriteLine($"The cinema is full.");
                    Console.WriteLine($"Cinema income - {allIncome} lv.");
                    fullhall = true;
                    break;
                }

                if (peopleInHall % 3 == 0)
                {
                    income += ((peopleInHall * 5) - 5);
                }
                else
                {
                    income += peopleInHall * 5;
                }

                input = Console.ReadLine();
            }
            if (!fullhall)
            {
                if (peopleInHall > hall)
                {
                    Console.WriteLine($"There are {hall - peopleInHall} seats left in the cinema.");
                }                                                 
                Console.WriteLine($"Cinema income - {allIncome} lv.");
            }
        }
    }
}
