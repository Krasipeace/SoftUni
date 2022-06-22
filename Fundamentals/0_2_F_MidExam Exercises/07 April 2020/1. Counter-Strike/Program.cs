using System;

namespace _1._Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string command = string.Empty;
            int counter = 0;

            while ((command = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(command);
                
                if (energy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {counter} won battles and {energy} energy");

                    return;
                }               
                counter++;
                energy -= distance;

                if (counter % 3 == 0)
                {
                    energy += counter;
                }
            }
            Console.WriteLine($"Won battles: {counter}. Energy left: {energy}");
        }
    }
}
