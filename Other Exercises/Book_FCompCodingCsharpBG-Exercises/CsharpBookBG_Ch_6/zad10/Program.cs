using System;

namespace zad10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number (N<20): ");
            int number = int.Parse(Console.ReadLine()); 
            
            for (int i = 1; i <= number; i++)
            {               
                for (int j = i; j < number + i; j++)
                {
                    Console.Write($"{j} ");
                    
                }
                Console.WriteLine();
            }
        }
    }
}
