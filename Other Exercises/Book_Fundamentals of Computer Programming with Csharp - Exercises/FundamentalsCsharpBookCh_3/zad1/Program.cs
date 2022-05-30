using System;

namespace zad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Напишете израз, който да проверява дали дадено цяло число е четно или нечетно.
            int number = int.Parse(Console.ReadLine());
            
            if (number % 2 == 0)
            {
                Console.WriteLine("The number is even!");
            }
            else
            {
                Console.WriteLine("The number is odd!");
            }            
        }
    }
}
