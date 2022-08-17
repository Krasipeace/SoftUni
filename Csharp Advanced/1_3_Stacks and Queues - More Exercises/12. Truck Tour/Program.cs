using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            Queue<int[]> queue = new Queue<int[]>();
           
            for (int i = 0; i < inputs; i++)
            {
                int[] petrolDistance = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(petrolDistance);
            }

            int startPetrolPump = 0;

            while (true)
            {
                bool isStartFound = true;
                int totalFuel = 0;

                foreach (var item in queue)
                {
                    int petrol = item[0];
                    int distance = item[1];
                    totalFuel += petrol;

                    if (totalFuel - distance < 0)
                    {
                        startPetrolPump++;
                        int[] currentPump = queue.Dequeue();
                        queue.Enqueue(currentPump);
                        isStartFound = false;
                        break;
                    }
                    totalFuel -= distance;
                }
                if (isStartFound)
                {
                    Console.WriteLine(startPetrolPump);
                    break;
                }
            }
        }
    }
}
