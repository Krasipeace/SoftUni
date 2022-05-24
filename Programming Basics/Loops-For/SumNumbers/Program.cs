using System;

namespace SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < inputNumber; i++)
            {           
                int number = int.Parse(Console.ReadLine());
                sum = sum + number;
            }
            Console.WriteLine(sum);
        }
    }
}
