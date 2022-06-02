using System;

namespace _1.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int trainLength = int.Parse(Console.ReadLine());
            int[] trainWagon = new int[trainLength];
            int sumPassengers = 0;            

            for (int i = 0; i < trainLength; i++)
            {
                trainWagon[i] = int.Parse(Console.ReadLine());               
                sumPassengers += trainWagon[i];                
            }
            for (int i = 0; i < trainLength; i++)
            {
                Console.Write($"{trainWagon[i]} ");
            }
            
            Console.WriteLine($"\n{sumPassengers}");
        }
    }
}
