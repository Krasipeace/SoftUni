using System;
using System.Collections.Generic;
using System.Linq;

namespace _16._Poisonous_Plants
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputPlants = int.Parse(Console.ReadLine());

            var plants = Console.ReadLine().Split(' ').Select(int.Parse).Take(inputPlants).ToList();

            Stack<int> deadPositions = new Stack<int>();

            int dayCounter = 0;

            while (true)
            {
                dayCounter++;

                int lastDayCounter = 0;

                for (int i = 0; i < inputPlants - 1; i++)
                {
                    if (plants[i + 1] > plants[i])
                    {
                        deadPositions.Push(i + 1);

                        lastDayCounter = 1;
                    }
                }

                int deadCounter = deadPositions.Count;

                for (int i = 0; i < deadCounter; i++)
                {
                    plants.RemoveAt(deadPositions.Pop());
                }

                inputPlants = plants.Count;

                if (lastDayCounter == 0)
                {
                    Console.WriteLine(dayCounter - 1);

                    return;
                }
            }
        }
    }
}
