using System;

namespace _1._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double foodQuantity = double.Parse(Console.ReadLine());
            double hayQuantity = double.Parse(Console.ReadLine());
            double coverQuantity = double.Parse(Console.ReadLine());
            double pigWeight = double.Parse(Console.ReadLine());

            for (int day = 1; day <= 30; day++)
            {
                foodQuantity -= 0.300;
                if (day % 2 == 0)
                {
                    hayQuantity -= foodQuantity * 0.05;
                }
                if (day % 3 == 0)
                {
                    coverQuantity -= pigWeight / 3;
                }

                if (foodQuantity <= 0.0 || hayQuantity <= 0.0 || coverQuantity <= 0.0)
                {       
                    Console.WriteLine("Merry must go to the pet store!");

                    return;
                }
            }
            if (foodQuantity > 0.0000001 && hayQuantity > 0.0000001 && coverQuantity > 0.0000001)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodQuantity:f2}, Hay: {hayQuantity:f2}, Cover: {coverQuantity:f2}.");
            }
            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
            
        }
    }
}
