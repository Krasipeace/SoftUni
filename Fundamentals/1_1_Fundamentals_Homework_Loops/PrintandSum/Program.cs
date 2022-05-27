using System;

namespace PrintandSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = numberOne; i <= numberTwo; i++)
            {
                sum += i;
                Console.Write($"{i} ");                
            }
            Console.WriteLine($"\nSum: {sum}");
        }
    }
}
