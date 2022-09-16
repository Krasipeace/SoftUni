using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;

            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command == "green")
                {
                    int greenLight = greenLightDuration;

                    while (greenLight > 0 && cars.Count > 0)
                    {
                        string carPassing = cars.Dequeue();
                        carsPassed++;
                        int carBody = carPassing.Length;

                        greenLight -= carBody;

                        if (greenLight < 0)
                        {
                            int carPart = freeWindow + (carBody - Math.Abs(greenLight));

                            if (carBody > carPart)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{carPassing} was hit at {carPassing[carPart]}.");

                                return;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
