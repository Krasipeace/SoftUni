using System;

namespace zad5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //5.Напишете програма, която чете от конзолата две цели числа (int) и отпечатва,
            //колко числа има между тях, такива, че остатъкът им от деленето на 5 да е 0. Пример: в интервала (17, 25) има 2 такива числа.

            Console.WriteLine("Find all numbers that can be divided by 5 in the interval you enter!");
            Console.Write("Enter begining of the interval: ");
            int intervalOne = int.Parse(Console.ReadLine());

            Console.Write("Enter end of the interval: ");
            int intervalTwo = int.Parse(Console.ReadLine());

            int counter = 0;
            for (int checkNumber = intervalOne; checkNumber <= intervalTwo; checkNumber++)
                if (checkNumber % 5 == 0)
                {
                    counter++;
                }
            Console.WriteLine("In this interval there are: " + counter + " number/s divided by 5");                     
        }
    }
}
