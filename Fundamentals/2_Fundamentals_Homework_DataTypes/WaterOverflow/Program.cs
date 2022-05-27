using System;

namespace WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte tries = byte.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= tries; i++)
            {
                int pourWater = int.Parse(Console.ReadLine());
                sum += pourWater;
                if (sum > 255)
                {
                    sum -= pourWater;
                    Console.WriteLine("Insufficient capacity!");                    
                }
            }
            Console.WriteLine(sum);
        }
    }
}
