using System;

namespace EvenNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            while (true)
            {
                number = int.Parse(Console.ReadLine());
                if (number % 2 == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                }
            }
            Console.WriteLine($"The number is: {Math.Abs(number)}");
        }         
    }
}
