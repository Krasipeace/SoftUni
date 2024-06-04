using System;

namespace cinema_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            double profit = 0;
            bool fullCinema = false;

            while (command != "Movie time!")
            {
                int people = int.Parse(command);
                capacity -= people;

                if (capacity < 0)
                {
                    Console.WriteLine("The cinema is full.");
                    fullCinema = true;
                    break;
                }

                if (people % 3 == 0)
                {
                    profit += (people * 5 - 5);
                }
                else
                {
                    profit += people * 5;
                }

                command = Console.ReadLine();
            }

            if (!fullCinema)
            {
                Console.WriteLine($"There are {capacity} seats left in the cinema.");
            }

            Console.WriteLine($"Cinema income - {profit} lv.");
        }
    }
}
