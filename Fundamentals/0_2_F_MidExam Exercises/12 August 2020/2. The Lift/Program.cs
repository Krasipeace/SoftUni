using System;
using System.Linq;

namespace _2._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleInQueue = int.Parse(Console.ReadLine());
            const int Max_Capacity_Of_Wagon = 4;

            int[] wagons = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(w => int.Parse(w)).ToArray();

            for (int i = 0; i < wagons.Length; i++)
            {
                for (int j = wagons[i]; j < Max_Capacity_Of_Wagon; j++)
                {
                    wagons[i]++;
                    peopleInQueue--;

                    if (peopleInQueue == 0)
                    {
                        if (wagons.Sum() < wagons.Length * Max_Capacity_Of_Wagon)
                        {
                            Console.WriteLine("The lift has empty spots!");
                        }
                        Console.WriteLine(string.Join(" ", wagons));

                        return;
                    }
                }
            }

            PrintWagonsData(peopleInQueue, wagons);
        }

        static void PrintWagonsData(int peopleInQueue, int[] wagons)
        {
            Console.WriteLine($"There isn't enough space! {peopleInQueue} people in a queue!");
            Console.WriteLine(string.Join(' ', wagons));
        }
    }
}
