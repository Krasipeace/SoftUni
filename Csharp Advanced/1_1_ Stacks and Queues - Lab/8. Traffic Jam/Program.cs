using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int passedCarsEachGreenLight = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int counter = 0;

            string input = Console.ReadLine();
            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < passedCarsEachGreenLight; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        string currentCar = cars.Dequeue();
                        counter++;
                        Console.WriteLine($"{currentCar} passed!");
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
